/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件由会员免费分享，如果商用，请务必联系原著购买授权！

daily assets update for try.

U should buy a license from author if u use it in your project!
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCar : MonoBehaviour
{

	CharacterController controller;
	public float speed = 6.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public bool onAir = false;
	float onAirStartTime;
	float onLandStartTime;
	public Vector3 m_RotationDirection;
	public float currentSpeed;
	public int rotations;
	float angle1, angle2, angledif;


	void Start ()
	{
		controller = GetComponent<CharacterController> ();
	}


	void Update()
	{ 
		if (controller.isGrounded) {
			onAir = false;
		}else if (!controller.isGrounded ) {
			onAir = true;
		} 

		if (onAir && Input.GetAxis("Vertical") > 0) {
			//SpinObj (); 
		} else if (!onAir) {
			moveDirection = new Vector3 (0, 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed + Mathf.Clamp (Mathf.Abs (transform.eulerAngles.x / 4), 0, 20);
			Quaternion	slopeRotation = Quaternion.FromToRotation (transform.up, hitNormal);
			transform.rotation = Quaternion.Slerp (transform.rotation, slopeRotation * transform.rotation, 10 * Time.deltaTime);
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime); //last move
	}

		
	void SpinObj ()
	{

		angle1 = transform.rotation.eulerAngles.y;
		transform.Rotate (m_RotationDirection * Time.deltaTime * currentSpeed);
		//angle2 = eulerAngle of axis after rotation applied
		angle2 = transform.rotation.eulerAngles.y;

		//Difference between angle2 and angle1, how much the object rotated between frames
		angledif = angle2 - angle1;
	
		if (angledif < 0) {
			++rotations;
		}
	}

	Vector3 hitNormal;

	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		onAir = false;
		hitNormal = hit.normal;
	}

}
