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
using System.Reflection;

public class RCC_MirrorsSetupEditor : Editor {

//	static GameObject selectedCar;
//
//	[MenuItem("Tools/BoneCracker Games/Realistic Car Controller/Create/Misc/Add Mirrors To Vehicle", false, -42)]
//	static void CreateBehavior(){
//
//		if(!Selection.activeGameObject.GetComponentInParent<RCC_CarControllerV3>()){
//
//			EditorUtility.DisplayDialog("Select a vehicle controlled by Realistic Car Controller!", "Select a vehicle controlled by Realistic Car Controller!", "Ok");
//
//		}else{
//
//			selectedCar = Selection.activeGameObject.GetComponentInParent<RCC_CarControllerV3>().gameObject;
//			CreateMirrors();
//
//		}
//
//	}
//
//	[MenuItem("Tools/BoneCracker Games/Realistic Car Controller/Create/Misc/Add Mirrors To Vehicle", true)]
//	static bool CheckCreateBehavior() {
//		if(Selection.gameObjects.Length > 1 || !Selection.activeTransform)
//			return false;
//		else
//			return true;
//	}
//
//	static void CreateMirrors () {
//
//		if(!selectedCar.transform.GetComponentInChildren<RCC_Mirror>()){
//			GameObject mirrors = (GameObject)Instantiate(RCC_Settings.Instance.mirrors, selectedCar.transform.position, selectedCar.transform.rotation);
//			mirrors.transform.SetParent(selectedCar.GetComponent<RCC_CarControllerV3>().chassis.transform, true);
//			mirrors.name = "Mirrors";
//			RCC_LabelEditor.SetIcon(mirrors.transform.GetChild(0).gameObject, RCC_LabelEditor.Icon.DiamondRed);
//			RCC_LabelEditor.SetIcon(mirrors.transform.GetChild(1).gameObject, RCC_LabelEditor.Icon.DiamondBlue);
//			RCC_LabelEditor.SetIcon(mirrors.transform.GetChild(2).gameObject, RCC_LabelEditor.Icon.DiamondTeal);
//			Selection.activeGameObject = mirrors;
//			EditorUtility.DisplayDialog("Created Mirrors!", "Created mirrors. Adjust their positions.", "Ok");
//		}else{
//			EditorUtility.DisplayDialog("Vehicle Has Mirrors Already", "Vehicle has mirrors already!", "Ok");
//		}
//	
//	}

}
