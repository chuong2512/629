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
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	public float speed, maxMagnitude, rotationSpeed, maxSpeed;
	public LayerMask lay;
	public bool gameover;
	public Text metersTxt;
	public Animator anim;
	Vector3 firstPos,lastPoint;
	bool isGrounded, touchDown;
	Vector3 dir;
	float exitTime, touDoTime, maxFOV, minFOV;
	Rigidbody rb;
	Camera cam;
	CanvasScript cs;
	InGame ig;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		FirstStep ();
	}

	void FirstStep()
	{
		gameover = true;
		rb = GetComponent<Rigidbody> ();
		cs = FindObjectOfType<CanvasScript> ();
		ig = FindObjectOfType<InGame> ();
		cam = Camera.main;
		maxFOV = 68f;
		minFOV = 60f;
		isGrounded = false;
		touchDown = false;
		firstPos = transform.position;
	}
	// Update is called once per frame
	void FixedUpdate () {
	
		if (!gameover) {
			CheckingTheGround ();
			//CheckingTheGroundForCharacters ();
			Touch ();
			Move ();
			DistanceCalculator ();
			rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxMagnitude);
		}
	}

	void CheckingTheGroundForCharacters()
	{
		
	}

	void CheckingTheGround()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -transform.up, out hit, 1f,layerMask:lay)) {
			if (hit.collider.tag == "Ground" && hit.collider != null) {
				rb.MoveRotation ( Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (Vector3.Cross (transform.right, hit.normal), hit.normal), Time.deltaTime * 5.0f));
				Debug.DrawRay (transform.position, -hit.normal, Color.red);
			} 
		}
	}

	void Touch()
	{
		if (Input.GetMouseButton (0)) {
			touchDown = true;
		} else {
			touchDown = false;
		}

//		if (Input.GetMouseButtonDown (0)) {
//			touchDown = true;
//		} 
//
//		if (Input.GetMouseButtonUp (0)) {
//			touchDown = false;
//		}
	}
		

	void Move()
	{
		if (isGrounded && (touchDown|| Input.GetKey(KeyCode.UpArrow))) {
			if (speed < maxSpeed) {
				speed += 5;
			}
			rb.AddForce(new Vector3(0,transform.forward.y,transform.forward.z) * speed * Time.deltaTime, ForceMode.Acceleration);
			if (anim)
				anim.SetBool ("Run", true);
		} else if ( (isGrounded && !touchDown) || (!isGrounded && !touchDown)) {
			if (speed > 500) {
				speed -= 5;
			} else {
				if (anim)
					anim.SetBool ("Run", false);
			}
		} else if(!isGrounded && (touchDown || Input.GetKey(KeyCode.UpArrow))){

			touDoTime = Time.time;
			float flyTime = touDoTime - exitTime;
			if (flyTime > 0.35) {
				Spin ();
			} 
		} 
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Ground") {
			isGrounded = true;
		}
		//OnTriggerEnter2( other);
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Ground") {
			isGrounded = false;
			exitTime = Time.time;

		}
	}

  void OnTriggerEnter2(Collider other){
 		if (other.gameObject.tag == "ExtraSpeed") {
 			maxMagnitude = 20;
 			rb.AddForce(new Vector3(0,transform.forward.y,transform.forward.z) * (speed + 100f) * Time.deltaTime, ForceMode.Acceleration);
 		}
 	}

	void DistanceCalculator()
	{
		float distance = Vector3.Distance (firstPos, transform.position);
		metersTxt.text = Mathf.Round (distance) + "m";
	}

	public Vector3 m_RotationDirection;
	public float currentSpeed;
	public int rotations;
	public GameObject targetObj;
	float angle1,angle2,angledif;
	void Spin () {

		angle1 = this.gameObject.transform.rotation.eulerAngles.y;
		transform.Rotate((m_RotationDirection * Time.deltaTime * currentSpeed));
		//angle2 = eulerAngle of axis after rotation applied
		angle2 = this.gameObject.transform.rotation.eulerAngles.y;
		//Difference between angle2 and angle1, how much the object rotated between frames
		angledif = angle2 - angle1;
		if ( angledif < 0)
		{
			++rotations;
			cs.coins += 25;
			cs.coinTxt.text = cs.coins.ToString ();
			PlayerPrefs.SetInt ("coins", cs.coins);
			CoinsEffect();
			cs.sideSource.PlayOneShot (cs.flip);
		}
	}

	void CoinsEffect()
	{
		ig = FindObjectOfType<InGame> ();
		Vector3 poss = Camera.main.WorldToScreenPoint (transform.position);
		ig.coinsCount.GetComponent<RectTransform> ().anchoredPosition = poss + new Vector3 (150, 150);
		ig.coinsCount.SetActive (true);

		for (int i = 0; i < 10; i++) {
			Image coinsEffectObj = Instantiate (ig.coinsEffect, poss + new Vector3 (Random.Range(120,500), Random.Range(120,500), 0), Quaternion.identity) ;
			coinsEffectObj.transform.parent = cs.transform;
			iTween.MoveTo(coinsEffectObj.gameObject,iTween.Hash("x",targetObj.transform.position.x,"y",targetObj.transform.position.y ,"z",targetObj.transform.position.z ,"easeType",iTween.EaseType.linear,"time",1.5f,"oncomplete","off","oncompletetarget", gameObject,"oncompleteparams", coinsEffectObj.gameObject));
		}
	}

	void off(GameObject go)
	{
		ig.coinsCount.SetActive (false);
		Destroy (go);
	}
}
