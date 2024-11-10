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
using UnityEngine.SceneManagement;
//using UnityEngine.Advertisements;

public class CanvasScript : MonoBehaviour {

	public static CanvasScript instance;
	public GameObject levelfail,inGame,menu;
	public Text coinTxt, coinsLvlFail;
	public GameObject[] cars;
	public AudioSource mainSource,sideSource;
	public AudioClip bg, flip, gameOver;
	[HideInInspector]
	public float fuelDecreaser, maxSpeed;
	[HideInInspector]
	public int coins;
	public CarSelection carSelection;
	//public string unityAdId;

	void Awake(){
		instance = this;
		ActivatingSelectedCars ();
		GettinData ();
	}

	void GettinData()
	{
		if (PlayerPrefs.HasKey ("coins")) {
			coins = PlayerPrefs.GetInt ("coins");
		} else {
			coins = 0;
			PlayerPrefs.SetInt ("coins", coins);
		}
		coinTxt.text = coins.ToString ();
		if (PlayerPrefs.HasKey ("fuelDecreaser")) {
			fuelDecreaser = PlayerPrefs.GetFloat ("fuelDecreaser");	
		} else {
			fuelDecreaser = 0.8f;
		}

		if (PlayerPrefs.HasKey ("maxSpeed")) {
			maxSpeed = PlayerPrefs.GetFloat ("maxSpeed");
		} else {
			maxSpeed = 1500f;
		}
	//	Advertisement.Initialize (unityAdId);
	}

	public void LevelFailPanel()
	{
		inGame.SetActive (false);
		levelfail.SetActive (true);
		menu.SetActive (false);
		sideSource.PlayOneShot (gameOver);
		coinsLvlFail.text = PlayerPrefs.GetInt ("coins").ToString ();
	}

	public void ActivatingSelectedCars()
	{
		PlayerPrefs.SetInt ("SelectedCar0", 0);
		for (int i = 0; i < cars.Length; i++) {
			if (i == CarSelection.count) {
				cars [i].SetActive ( true);
			} else {
				cars [i].SetActive ( false);
			}
		}
	}

	public void CointinueBtn()
	{
//		if (Advertisement.IsReady ())
//			Advertisement.Show ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
