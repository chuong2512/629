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

/// <summary>
/// Receives float from UI Slider, and displays the value as a text.
/// </summary>
public class RCC_UISliderTextReader : MonoBehaviour {

	public Slider slider;
	public Text text;

	void Awake () {

		if(!slider)
			slider = GetComponentInParent<Slider> ();
		
		if(!text)
			text = GetComponentInChildren<Text> (); 
	
	}

	void Update () {
		
		text.text = slider.value.ToString ("F1");

	}

}
