/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件由会员免费分享，如果商用，请务必联系原著购买授权！

daily assets update for try.

U should buy a license from author if u use it in your project!
*/

//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2016 BoneCracker Games
// http://www.bonecrackergames.com
//
//----------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// Feeding material's emission channel for self illumin effect.
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Light/Light Emission")]
public class RCC_LightEmission : MonoBehaviour {

	private Light sharedLight;
	public Renderer lightRenderer;
	public int materialIndex = 0;
	public bool noTexture = false;

	void Start () {

		sharedLight = GetComponent<Light>();
		Material m = lightRenderer.materials[materialIndex];
		m.EnableKeyword("_EMISSION");
	 
	}

	void Update () {

		if(!sharedLight.enabled){
			lightRenderer.materials[materialIndex].SetColor("_EmissionColor", Color.white * 0f);
			return;
		}

		if(!noTexture)
			lightRenderer.materials[materialIndex].SetColor("_EmissionColor", Color.white * sharedLight.intensity);
		else
			lightRenderer.materials[materialIndex].SetColor("_EmissionColor", Color.red * sharedLight.intensity);
	
	}

}
