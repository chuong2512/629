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
/// Rotating and moving suspension arms based on wheelcollider suspension distance.
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Misc/Suspension Distance Based Axle")]
public class RCC_SuspensionArm : MonoBehaviour {

	public WheelCollider wheelcollider;

	public Axis axis;
	public enum Axis {X, Y, Z}

	private Vector3 orgRot;
	private float totalSuspensionDistance = 0;

	public float offsetAngle = 30;
	public float angleFactor = 150;
	
	void Start () {
		
		orgRot = transform.localEulerAngles;
		totalSuspensionDistance = GetSuspensionDistance ();

	}

	void Update () {
		
		float suspensionCourse = GetSuspensionDistance () - totalSuspensionDistance;
		transform.localEulerAngles = orgRot;

		switch(axis){

		case Axis.X:
			transform.Rotate (Vector3.right, suspensionCourse * angleFactor - offsetAngle, Space.Self);
			break;
		case Axis.Y:
			transform.Rotate (Vector3.up, suspensionCourse * angleFactor - offsetAngle, Space.Self);
			break;
		case Axis.Z:
			transform.Rotate (Vector3.forward, suspensionCourse * angleFactor - offsetAngle, Space.Self);
			break;

		}

	}
		
	private float GetSuspensionDistance() {
		
		Quaternion quat;
		Vector3 position;
		wheelcollider.GetWorldPose(out position, out quat);
		Vector3 local = wheelcollider.transform.InverseTransformPoint (position);
		return local.y;

	}

}
