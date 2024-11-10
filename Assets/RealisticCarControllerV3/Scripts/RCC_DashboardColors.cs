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
using UnityEngine.UI;

/// <summary>
/// Changes HUD image colors by UI Sliders.
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/UI/Dashboard Colors")]
public class RCC_DashboardColors : MonoBehaviour {

	public Image[] huds;
	public Color hudColor = Color.white;

	public Slider hudColor_R;
	public Slider hudColor_G;
	public Slider hudColor_B;

	void Awake () {

		if(huds == null || huds.Length < 1)
			enabled = false;

		if(hudColor_R && hudColor_G && hudColor_B){
			hudColor_R.value = hudColor.r;
			hudColor_G.value = hudColor.g;
			hudColor_B.value = hudColor.b;
		}
	
	}

	void Update () {

		if(hudColor_R && hudColor_G && hudColor_B)
			hudColor = new Color(hudColor_R.value, hudColor_G.value, hudColor_B.value);

		for (int i = 0; i < huds.Length; i++) {

			huds[i].color = new Color(hudColor.r, hudColor.g, hudColor.b, huds[i].color.a);

		}
	
	}

}
