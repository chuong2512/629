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

public class SpinTest : MonoBehaviour {


	public Vector3 m_RotationDirection;
	public float currentSpeed;
	public int rotations;
	public GameObject obj,targetObj;
	// Use this for initialization
	void Start()
	{
		Test ();
	}

	// Update is called once per frame
	float angle1,angle2,angledif;
	void Update () {

		angle1 = this.gameObject.transform.rotation.eulerAngles.y;
		transform.Rotate(m_RotationDirection * Time.deltaTime * currentSpeed);
		//angle2 = eulerAngle of axis after rotation applied
		angle2 = this.gameObject.transform.rotation.eulerAngles.y;
		//Difference between angle2 and angle1, how much the object rotated between frames
		angledif = angle2 - angle1;


		if ( angledif < 0)
		{
			++rotations;

		}
	}

	void Test()
	{
		for (int i = 0; i < 10; i++) {
			GameObject coinsEffectObj = Instantiate (obj, transform.position + new Vector3 (1, 1, 0), Quaternion.identity);
			Vector3 pos = new Vector3 (Random.Range (coinsEffectObj.transform.position.x - 0.5f, coinsEffectObj.transform.position.x + 0.5f), Random.Range (coinsEffectObj.transform.position.y - 0.5f, coinsEffectObj.transform.position.y + 0.5f), 0);
			iTween.MoveTo(coinsEffectObj,iTween.Hash("x",pos.x,"y",pos.y,"easeType",iTween.EaseType.linear,"time",Random.Range(0.35f,0.65f),"oncomplete","AfterCompletion","oncompletetarget", gameObject,"oncompleteparams", coinsEffectObj));
		}
	}

	void AfterCompletion(GameObject go)
	{
		iTween.MoveTo(go,iTween.Hash("x",targetObj.transform.position.x,"y",targetObj.transform.position.y,"z",Camera.main.transform.position.z + 9,"easeType",iTween.EaseType.linear,"time",1f));
	}
}
