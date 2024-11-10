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
using System.Collections;

/// <summary>
/// Used for changing wheels (visual only) at runtime. It holds changable wheels as prefab in an array.
/// </summary>
[System.Serializable]
public class RCC_ChangableWheels : ScriptableObject {
	
	#region singleton
	public static RCC_ChangableWheels instance;
	public static RCC_ChangableWheels Instance{	get{if(instance == null) instance = Resources.Load("RCCAssets/RCC_ChangableWheels") as RCC_ChangableWheels; return instance;}}
	#endregion

	[System.Serializable]
	public class ChangableWheels{
		
		public GameObject wheel;

	}
		
	public ChangableWheels[] wheels;

}


