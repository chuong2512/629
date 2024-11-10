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
using System;
using System.Collections;

[CustomEditor(typeof(RCC_EnterExitPlayer)), CanEditMultipleObjects]
public class RCC_EnterExitEditor : Editor {

	RCC_EnterExitPlayer prop;

	public override void OnInspectorGUI () {

		serializedObject.Update ();
		prop = (RCC_EnterExitPlayer)target;

		EditorGUILayout.PropertyField(serializedObject.FindProperty("playerType"), new GUIContent("Player Type", "FPS or TPS?"), false);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("rootOfPlayer"), new GUIContent("Player Root", "Root Of The Player"), false);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("maxRayDistance"), new GUIContent("Maximum Ray Distance"), false);

		if (prop.playerType == RCC_EnterExitPlayer.PlayerType.TPS) {
			EditorGUILayout.PropertyField(serializedObject.FindProperty("rayHeight"), new GUIContent("Ray Pivot Height"), false);
			EditorGUILayout.PropertyField (serializedObject.FindProperty ("TPSCamera"), new GUIContent ("External TPS Camera", "If you TPS player has individual seperate camera (not parented to TPS player), you can select it here. It will enable/disable it when player gets in/out of the vehicle"), false);
		}

		serializedObject.ApplyModifiedProperties ();

	}

}
