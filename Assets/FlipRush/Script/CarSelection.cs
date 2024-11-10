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

public class CarSelection : MonoBehaviour {

	public GameObject[] cars;
	public Text prices, coinsTxt;
	public static int count = 0;


	void Start(){
		PriceCheck (count);
	}

	public void Left()
	{
		if (count <= 0) {
			count = 0;
		}
		if (count > 0) {
			iTween.MoveTo (cars [count], iTween.Hash ("x", 5f, "easeType", iTween.EaseType.linear, "time", 1f));
			count--;
			iTween.MoveTo (cars [count], iTween.Hash ("x", 0, "easeType", iTween.EaseType.linear, "time", 1f));
			PriceCheck (count);
		}
	}

	public void Right()
	{
		if (count >= cars.Length - 2) {
			count = cars.Length - 2;
		}
		if (count < 5) {
			iTween.MoveTo (cars [count], iTween.Hash ("x", -5, "easeType", iTween.EaseType.linear, "time", 1f));
			count++;
			iTween.MoveTo(cars[count],iTween.Hash("x",0,"easeType", iTween.EaseType.linear, "time", 1f));
			PriceCheck (count);
		}
	}

	public void Close()
	{
		SceneManager.LoadScene ("1");
	}
	int coins;
	public void SelectedCar()
	{
		if (prices.text == "Selecte") {
			PlayerPrefs.SetInt ("SelectedCar" + count, count);
		}else {
			coins = PlayerPrefs.GetInt ("coins");
			if (coins >= 300) {
				coins -= 300;
				PlayerPrefs.SetInt ("coins", coins);
				prices.text = "select";
				coinsTxt.text = coins.ToString ();
				PlayerPrefs.SetInt ("SelectedCar" + count, count);
			} else {
				prices.text = "300 coins";
			}
		}
	}

	void PriceCheck(int Viewcar)
	{
		coins = PlayerPrefs.GetInt ("coins");
		coinsTxt.text = coins.ToString ();

		PlayerPrefs.SetInt ("SelectedCar0", 0);

		if (PlayerPrefs.GetInt ("SelectedCar" + count) == count) {
				prices.text = "Select";
		} else if( PlayerPrefs.GetInt ("SelectedCar" + count) != count){
				prices.text = "300 Coins";
		}

	}
}
