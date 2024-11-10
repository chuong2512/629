/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件由会员免费分享，如果商用，请务必联系原著购买授权！

daily assets update for try.

U should buy a license from author if u use it in your project!
*/

//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2016 BoneCracker Games
// http://www.bonecrackergames.com
//
//----------------------------------------------

using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(RCC_AIWaypointsContainer))]
public class RCC_AIWPEditor : Editor {
	
	RCC_AIWaypointsContainer wpScript;
	
	public override void  OnInspectorGUI () {
		
		serializedObject.Update();

		wpScript = (RCC_AIWaypointsContainer)target;

		EditorGUILayout.PropertyField(serializedObject.FindProperty("type"), new GUIContent("Type", "Type"), false);

		switch (wpScript.type) {

		case RCC_AIWaypointsContainer.Type.ChaseThisObject:

			EditorGUILayout.PropertyField(serializedObject.FindProperty("target"), new GUIContent("Target", "Target"), false);

			break;

		case RCC_AIWaypointsContainer.Type.FollowWaypoints:

			EditorGUILayout.HelpBox("Create Waypoints By Shift + Left Mouse Button On Your Road", MessageType.Info);

			EditorGUILayout.PropertyField(serializedObject.FindProperty("waypoints"), new GUIContent("Waypoints", "Waypoints"), true);

			if (GUILayout.Button ("Delete Waypoints")) {
				foreach (Transform t in wpScript.waypoints) {
					DestroyImmediate (t.gameObject);
				}
				wpScript.waypoints.Clear ();
			}

			break;

		}
			

			



		serializedObject.ApplyModifiedProperties();
		
	}

	void OnSceneGUI(){

		Event e = Event.current;
		wpScript = (RCC_AIWaypointsContainer)target;

		if(e != null){

			if(e.isMouse && e.shift && e.type == EventType.MouseDown){

				Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(ray, out hit, 5000.0f)) {

					Vector3 newTilePosition = hit.point;

					GameObject wp = new GameObject("Waypoint " + wpScript.waypoints.Count.ToString());

					wp.transform.position = newTilePosition;
					wp.transform.SetParent(wpScript.transform);

					GetWaypoints();

				}

			}

			if(wpScript)
				Selection.activeGameObject = wpScript.gameObject;

		}

		GetWaypoints();

	}
	
	public void GetWaypoints(){
		
		wpScript.waypoints = new List<Transform>();
		
		Transform[] allTransforms = wpScript.transform.GetComponentsInChildren<Transform>();
		
		foreach(Transform t in allTransforms){
			
			if(t != wpScript.transform)
				wpScript.waypoints.Add(t);
			
		}
		
	}
	
}
