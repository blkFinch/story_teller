using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlocking : MonoBehaviour {

	public GameObject[] blockingPrefabs;
	public int sceneToLoad;

	private GameObject setting;

	void Start(){
		setting = Instantiate(blockingPrefabs[sceneToLoad]) as GameObject;
	}


}
