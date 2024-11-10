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
using System.Collections.Generic;

/// <summary>
/// Used for holding a list for waypoints, and drawing gizmos for all of them.
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/AI/Waypoints Container")]
public class RCC_AIWaypointsContainer : MonoBehaviour {

	public Type type;
	public enum Type {FollowWaypoints, ChaseThisObject}

	public List<Transform> waypoints = new List<Transform>();
	public Transform target;

	// Used for drawing gizmos on Editor.
	void OnDrawGizmos() {
		
		for(int i = 0; i < waypoints.Count; i ++){
			
			Gizmos.color = new Color(0.0f, 1.0f, 1.0f, 0.3f);
			Gizmos.DrawSphere (waypoints[i].transform.position, 2);
			Gizmos.DrawWireSphere (waypoints[i].transform.position, 20f);
			
			if(i < waypoints.Count - 1){
				
				if(waypoints[i] && waypoints[i+1]){
					
					if (waypoints.Count > 0) {
						
						Gizmos.color = Color.green;

						if(i < waypoints.Count - 1)
							Gizmos.DrawLine(waypoints[i].position, waypoints[i+1].position); 
						if(i < waypoints.Count - 2)
							Gizmos.DrawLine(waypoints[waypoints.Count - 1].position, waypoints[0].position); 
						
					}

				}

			}

		}
		
	}
	
}