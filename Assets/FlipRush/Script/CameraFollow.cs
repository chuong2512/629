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

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public float followSpeed;
	private Vector3 offset;
	private PlayerController playerCon;
	private Camera cam;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerCon = player.GetComponent<PlayerController> ();
		cam = GetComponent<Camera> ();
		offset =  transform.position - player.transform.position;
		transform.position = player.transform.position + offset;
	}

	Vector3 targetPos;
	// Update is called once per frame
	void LateUpdate () {
		targetPos = player.transform.position + offset;
		transform.position = Vector3.MoveTowards (transform.position, targetPos, followSpeed * Time.deltaTime);
	}
}
