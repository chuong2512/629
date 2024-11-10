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


public class InGame : MonoBehaviour {

	private PlayerController pc;
	public Image speedOMeter,fuelMeter;
	public GameObject coinsCount;
	public Image coinsEffect;
	public Text mphTxt,fuelTxt;

	// Use this for initialization
	void Start () {
		pc = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		CalculatingSpeedOMeter ();
		CalculatingFuelMeter ();
	}


	float speed, differenceSpeed;
	void CalculatingSpeedOMeter()
	{
		// 500 is the base speed and 1500 is the top speed
		//speed =( (pc.speed) *0.001f);
		if (!pc.gameover) {
			differenceSpeed = speed = (pc.maxSpeed - pc.speed);
			speed = ((1000 - speed) / 1000);
			speedOMeter.fillAmount = speed;	
			mphTxt.text = (speed * 1000).ToString () + " kmph";
		} else {
			speed = 0;
			mphTxt.text = "0";
			speedOMeter.fillAmount = 0;
		}
	}

	float fuel = 100;
	float fuelDecreaser;
	void CalculatingFuelMeter()
	{
		if (!pc.gameover) {
			// getting the fueldecreaser from playerprefs
			if (PlayerPrefs.HasKey ("fuelDecreaser")) {
				fuelDecreaser = PlayerPrefs.GetFloat ("fuelDecreaser");
			} else {
				fuelDecreaser = 0.8f;
			}
			// decreasing by fuelDecreaser..
			if (pc.speed > 600) {
				fuel = (fuel - (fuelDecreaser * Time.deltaTime));
				fuelTxt.text = Mathf.RoundToInt (fuel).ToString () + "%";
				fuelMeter.fillAmount = Mathf.RoundToInt (fuel) * 0.01f;
			}

			// checking the fuel
			if(fuel <= 0){
				pc.gameover = true;
			}
		}
	}


}
