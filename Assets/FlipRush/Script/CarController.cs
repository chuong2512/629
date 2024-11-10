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

public class CarController : MonoBehaviour {

	public float speed = 6.0f, maxSpeed = 15f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public LayerMask lay;
	public Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	[SerializeField]
	bool clicked, isgrounded;

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		CheckingTheGround ();
	}
		
	void CheckingTheGround()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -transform.up, out hit, 1f,layerMask:lay)) {
			if (hit.collider.tag == "Ground" && hit.collider != null) {
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (Vector3.Cross (transform.right, hit.normal), hit.normal), Time.deltaTime * 5.0f);
				isgrounded = true;
				Debug.DrawRay (transform.position, -hit.normal, Color.red);
			} else if (hit.collider == null){
				isgrounded = false;
				clicked = false;
			}
		}
	}

	void Test()
	{
	if (isgrounded && Input.GetMouseButtonDown(0))
		{
			clicked = true;
		}
		if (!isgrounded || Input.GetMouseButtonUp (0)) {
			clicked = false;
		}

		if (clicked == false) {
			if (speed > 0) {
				speed = Mathf.Floor (speed - (5f * Time.deltaTime));
				moveDirection =  transform.TransformDirection(new Vector3(0, 0, Vector3.forward.z) * speed); 
			}
		} else if (clicked) {
			if(speed < maxSpeed)
				speed += 5f * Time.deltaTime;
			moveDirection = new Vector3(0, 0, 1);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection = moveDirection * speed;
		}
		// Apply gravity
		moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
		// Move the controller
		controller.Move(moveDirection * Time.deltaTime);
	}
}
