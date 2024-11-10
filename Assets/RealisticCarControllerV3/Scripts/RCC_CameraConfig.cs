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
/// Used for setting new camera settings to RCC Camera.
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Camera/Auto Camera Config")]
public class RCC_CameraConfig : MonoBehaviour {

	public bool automatic = true;
	private Bounds combinedBounds;

	public float distance = 10f;
	public float height = 5f;

	void Awake(){

		if(automatic){

			Quaternion orgRotation = transform.rotation;
			transform.rotation = Quaternion.identity;

			distance = MaxBoundsExtent(transform) * 1.2f;
			height = MaxBoundsExtent(transform) * .5f;

			if (height < 1)
				height = 1;

			transform.rotation = orgRotation;

		}

	}

	public void SetCameraSettings () {

		RCC_Camera cam = GameObject.FindObjectOfType<RCC_Camera>();
		 
		if(!cam)
			return;
			
		cam.TPSDistance = distance;
		cam.TPSHeight = height;

	}

	public static float MaxBoundsExtent(Transform obj){
		
		// get the maximum bounds extent of object, including all child renderers,
		// but excluding particles and trails, for FOV zooming effect.

		var renderers = obj.GetComponentsInChildren<Renderer>();

		Bounds bounds = new Bounds();
		bool initBounds = false;
		foreach (Renderer r in renderers)
		{
			if (!((r is TrailRenderer) || (r is ParticleSystemRenderer)))
			{
				if (!initBounds)
				{
					initBounds = true;
					bounds = r.bounds;
				}
				else
				{
					bounds.Encapsulate(r.bounds);
				}
			}
		}
		float max = Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z);
		return max;

	}

}
