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

public class Menu : MonoBehaviour {


	public Text lvlforSpeedtxt,coinsforSpeedtxt,lvlforFueltxt,coinsforFueltxt;
	public Image sound;
	public Sprite soundOn,soundOff;
	private int lvlforSpeed, coinsforSpeed, lvlforFuel, coinsforFuel;
	private CanvasScript cs;
	private PlayerController pc;
	// Use this for initialization
	void Start () {
		cs = FindObjectOfType<CanvasScript> ();
		pc = FindObjectOfType<PlayerController>();
		GettinData ();
	}

	void GettinData()
	{
		lvlforSpeed = PlayerPrefs.GetInt ("lvlforSpeed");
		coinsforSpeed = PlayerPrefs.GetInt ("coinsforSpeed");
		lvlforFuel = PlayerPrefs.GetInt ("lvlforFuel");
		coinsforFuel = PlayerPrefs.GetInt ("coinsforFuel");
		if (lvlforFuel == 0 || lvlforSpeed == 0) {
			lvlforFuel = 01;
			lvlforSpeed = 01;
		}
		if (coinsforFuel == 0 || coinsforSpeed == 0) {
			coinsforFuel = 300;
			coinsforSpeed = 300;
		}

		GivingTheValues ();
	}

	void GivingTheValues()
	{
		lvlforFueltxt.text = "0"+lvlforFuel.ToString ();
		coinsforFueltxt.text = coinsforFuel.ToString () + " Coins";
		lvlforSpeedtxt.text = "0"+lvlforFuel.ToString ();
		coinsforSpeedtxt.text = coinsforSpeed.ToString ()+ " Coins";
		cs.coinTxt.text = cs.coins.ToString ();
	}

	public void FuelUp()
	{
		if (cs.coins >= coinsforFuel) {
			cs.coins = Mathf.Abs (cs.coins - coinsforFuel);
			coinsforFuel += 300;
			lvlforFuel += 1;
			coinsforFueltxt.text = coinsforFuel.ToString ();
			lvlforFueltxt.text = lvlforFuel.ToString ();
			cs.fuelDecreaser -= 0.05f;
			PlayerPrefs.SetFloat ("fuelDecreaser", cs.fuelDecreaser);
			PlayerPrefs.SetInt ("coinsforFuel", coinsforFuel);
			PlayerPrefs.SetInt ("lvlforFuel", lvlforFuel);
			PlayerPrefs.SetInt ("coins", cs.coins);
		}
	}

	public void speedUp()
	{
		if (cs.coins >= coinsforSpeed) {
			cs.coins = Mathf.Abs (cs.coins - coinsforSpeed);
			coinsforSpeed += 300;
			lvlforSpeed += 1;
			coinsforSpeedtxt.text = coinsforSpeed.ToString ();
			lvlforSpeedtxt.text = lvlforSpeed.ToString ();
			PlayerPrefs.SetInt ("coinsforSpeed", coinsforSpeed);
			PlayerPrefs.SetInt ("lvlforSpeed", lvlforSpeed);
			PlayerPrefs.SetInt ("coins", cs.coins);
		}
	}

	public void CarSelection()
	{
		SceneManager.LoadScene ("CarSelection");
	}

	public void play()
	{
		pc.gameover = false;
		cs.inGame.SetActive (true);
		this.gameObject.SetActive (false);
	}

	public void SoundBtn()
	{
		if (cs.mainSource.volume == 0) {
			cs.mainSource.volume = 1;
			sound.sprite = soundOn;
		} else if (cs.mainSource.volume == 1){
			cs.mainSource.volume = 0;
			sound.sprite = soundOff;
		}
	}
}
