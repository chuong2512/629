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
/// RCC Camera will be parented to this gameobject when current camera mode is Hood Camera.
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Camera/Hood Camera")]
public class RCC_HoodCamera : MonoBehaviour {

	void Start () {

		StartCoroutine ("FixShakeDelayed");
	
	}

	public void FixShake(){

		StartCoroutine ("FixShakeDelayed");
		
	}

	IEnumerator FixShakeDelayed(){

		if (!GetComponent<Rigidbody> ())
			yield return null;

		yield return new WaitForFixedUpdate ();
		GetComponent<Rigidbody> ().interpolation = RigidbodyInterpolation.None;
		yield return new WaitForFixedUpdate ();
		GetComponent<Rigidbody> ().interpolation = RigidbodyInterpolation.Interpolate;

	}

}

