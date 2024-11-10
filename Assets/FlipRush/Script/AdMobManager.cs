/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件由会员免费分享，如果商用，请务必联系原著购买授权！

daily assets update for try.

U should buy a license from author if u use it in your project!
*/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AdMobManager : MonoBehaviour
{
	public static AdMobManager _AdMobInstance;
	public string bannerAdId, interstitialAdId, rewardVideoAdId;
	public bool  isDebug;
	public  bool isOnTop;
    [HideInInspector]
   

	// Use this for initialization

	void Awake ()
	{
		if (_AdMobInstance) {
			DestroyImmediate (gameObject);
		} else {
			DontDestroyOnLoad (gameObject);
			_AdMobInstance = this;
		}
	}


	void Start ()
	{
		loadRewardVideo ();
		loadInterstitial ();
		showBannerAd ();
	}
	
	// Update is called once per frame

	void OnGUI ()
	{
		if (isDebug) {
			if (GUI.Button (new Rect (20, 0, 100, 60), "Load Full")) {
				loadInterstitial ();
			}
			if (GUI.Button (new Rect (20, 80, 100, 60), "Load Video")) {
				loadRewardVideo ();
			}
			if (GUI.Button (new Rect (20, 160, 100, 60), "Show Banner")) {
				showBannerAd ();
			}
			if (GUI.Button (new Rect (200, 0, 100, 60), "Show Full")) {
				showInterstitial ();
			}
			if (GUI.Button (new Rect (200, 80, 100, 60), "Show Video")) {
				showRewardVideo ();
			}
			if (GUI.Button (new Rect (200, 160, 100, 60), "Hide Banner")) {
				hideBannerAd ();
			}
		

		}
	}

    void onInterstitialEvent (object sender, System.EventArgs args)
	{
		print("OnAdLoaded event received.");
		// Handle the ad loaded event.
	}
	void onInterstitialCloseEvent (object sender, System.EventArgs args)
	{
		print("OnAdLoaded event received.");
		// Handle the ad loaded event.
	}

	void onBannerEvent (string eventName, string msg)
	{
		
	}



	public  void showBannerAd ()
	{
	

	}
		

	public  void loadInterstitial ()
	{
	
	}

	public  void showInterstitial ()
	{
		
	
    }

	public  void loadRewardVideo ()
	{
	
	}

	public  void showRewardVideo ()
	{		
	
	}
	
	public  void hideBannerAd ()
	{
	}


}
