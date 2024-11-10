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

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(RCC_GroundMaterials))]
public class RCC_PhysicMaterialsEditor : Editor {

	RCC_GroundMaterials physicMats;
	Color originalGUIColor;
	string[] physicMatsNames;
	Vector2 scrollPos;

	public override void OnInspectorGUI () {

		serializedObject.Update();

		physicMats = (RCC_GroundMaterials)target;

		originalGUIColor = GUI.backgroundColor;

		scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false );


		/////////////////////////


		GUILayout.Label("Ground Physic Materials", EditorStyles.boldLabel);

		EditorGUI.indentLevel++;

		EditorGUILayout.BeginVertical(GUI.skin.box);

		EditorGUILayout.PropertyField(serializedObject.FindProperty("frictions"), new GUIContent("Ground Physic Materials"), true);

		EditorGUILayout.EndVertical();

		EditorGUILayout.Space();

		EditorGUILayout.BeginVertical(GUI.skin.box);

		for (int i = 0; i < physicMats.frictions.Length; i++) {

			EditorGUILayout.BeginVertical(GUI.skin.box);

			if(physicMats.frictions[i].groundMaterial != null){
				GUILayout.Label(physicMats.frictions[i].groundMaterial.name, EditorStyles.boldLabel);
				EditorGUILayout.Space(); 
				physicMats.frictions[i].groundMaterial.staticFriction = physicMats.frictions[i].groundMaterial.dynamicFriction = EditorGUILayout.FloatField("Forward And Sideways Stiffness", physicMats.frictions[i].groundMaterial.staticFriction);
				physicMats.frictions[i].groundParticles = (GameObject)EditorGUILayout.ObjectField("Wheel Particles", physicMats.frictions[i].groundParticles, typeof(GameObject), false);
				physicMats.frictions[i].groundSound = (AudioClip)EditorGUILayout.ObjectField("Wheel Sound", physicMats.frictions[i].groundSound, typeof(AudioClip), false);
			}else{
				GUI.color = Color.red;
				GUILayout.Label("Null. Select One Material!", EditorStyles.boldLabel);
				GUI.color  = originalGUIColor;
			}
			 
			EditorGUILayout.EndVertical();
			
		}

		EditorGUILayout.EndVertical();

		EditorGUILayout.EndScrollView();

		GUI.color = new Color(.5f, 1f, 1f, 1f);

		if(GUILayout.Button(" <-- Return To RCC Settings")){
			Selection.activeObject = Resources.Load("RCCAssets/RCCAssetSettings") as RCC_Settings;
		}

		GUI.color = originalGUIColor;


		/////////////////////////


		serializedObject.ApplyModifiedProperties();

		if(GUI.changed)
			EditorUtility.SetDirty(physicMats);
	
	}

}
