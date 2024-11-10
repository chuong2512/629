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

public class LevelGenerator : MonoBehaviour {


	public List<GameObject> tracksPrefab;
	public List<GameObject> LoadedPrefabs;
	private GameObject pc;
	int count=0;
	// Use this for initialization
	void Start () {
		pc = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){
		LevelCreator ();
	}

	 void  LevelCreator()
	{
		if(pc.transform.position.z >= LoadedPrefabs[LoadedPrefabs.Count - 2].transform.position.z && LoadedPrefabs.Count > 1){
			for (int i = 0; i < 10; i++) {
				LevelObjectCreator ();
				if (LoadedPrefabs.Count > 21) {
					GameObject temp = LoadedPrefabs [0];
					LoadedPrefabs.RemoveAt (0);
					Destroy (temp);
				}
			}	
		}
	}
	 void LevelObjectCreator()
	{
		int num = Random.Range (0, tracksPrefab.Count);
		int lastInstantiatedGO = LoadedPrefabs.Count - 1;

		float zPos = LoadedPrefabs [lastInstantiatedGO].transform.GetChild (0).transform.GetChild (1).transform.position.z;
		GameObject track = Instantiate(tracksPrefab[num]) ;
		track.SetActive (true);
		track.transform.position = new Vector3(0,0,zPos);
		track.transform.rotation = Quaternion.identity;
		track.name = "track " + count;
		count++;
		track.transform.parent = GameObject.Find ("Tracks").transform;
		LoadedPrefabs.Add (track);
	}
}
