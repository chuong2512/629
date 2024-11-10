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
/// Tracks the car and keeps orientation nicely for cinematic angles. It has a pivot gameobject named "Animation Pivot". This gameobject has 3 animations itself. 
/// </summary>
public class RCC_CinematicCamera : MonoBehaviour {

	internal Transform currentCar;		// Car we are tracking. It will be selected while you are changing camera mode automatically.
	private RCC_Camera rccCamera;		// Main RCC Camera.

	public GameObject pivot;		// Animation Pivot.

	private Vector3 targetPosition;		// Target position for tracking.

	public float targetFOV = 60f;		// Target field of view.

	void Awake () {

		// If pivot is not selected in Inspector Panel, create it.
		if (!pivot) {
			
			pivot = new GameObject ("Pivot");
			pivot.transform.SetParent (transform, false);
			pivot.transform.localPosition = Vector3.zero;
			pivot.transform.localRotation = Quaternion.identity;

		}
	
	}

	void Update () {

		// If RCC Camera is not selected in Inspector Panel, create it.
		if (!rccCamera) {
			rccCamera = GameObject.FindObjectOfType<RCC_Camera> ();
			return;
		}

		// If current car is null, get it from RCC Camera.
		if (!currentCar) {
			currentCar = rccCamera.playerCar;
			return;
		}

		// Rotates smoothly towards to car.
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, currentCar.transform.eulerAngles.y + 180, transform.eulerAngles.z), Time.deltaTime * 3f);

		// Calculating target position.
		targetPosition = currentCar.position;
		targetPosition -= transform.rotation * Vector3.forward * 10f;

		// Assigning transform.position to targetPosition.
		transform.position = targetPosition;

	}

}
