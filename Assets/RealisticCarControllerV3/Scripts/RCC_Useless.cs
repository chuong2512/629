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
using UnityEngine.UI;
using System.Collections;

public class RCC_Useless : MonoBehaviour {

	public Useless useless;
	public enum Useless{Controller, Behavior}

	// Use this for initialization
	void Awake () {

		int type = 0;

		if(useless == Useless.Behavior){

			RCC_Settings.BehaviorType behavior = RCC_Settings.Instance.behaviorType;

			switch(behavior){
			case(RCC_Settings.BehaviorType.Simulator):
				type = 0;
				break;
			case(RCC_Settings.BehaviorType.Racing):
				type = 1;
				break;
			case(RCC_Settings.BehaviorType.SemiArcade):
				type = 2;
				break;
			case(RCC_Settings.BehaviorType.Drift):
				type = 3;
				break;
			case(RCC_Settings.BehaviorType.Fun):
				type = 4;
				break;
			case(RCC_Settings.BehaviorType.Custom):
				type = 5;
				break;
			}

		}else{

			if(!RCC_Settings.Instance.useAccelerometerForSteering && !RCC_Settings.Instance.useSteeringWheelForSteering)
				type = 0;
			if(RCC_Settings.Instance.useAccelerometerForSteering)
				type = 1;
			if(RCC_Settings.Instance.useSteeringWheelForSteering)
				type = 2;

		}

		GetComponent<Dropdown>().value = type;
		GetComponent<Dropdown>().RefreshShownValue();
	
	}

}
