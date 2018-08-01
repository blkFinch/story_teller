using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

	private LevelManager lm;

	public string levelToLoad;
	// Use this for initialization
	void Start () {
		lm = Object.FindObjectOfType<LevelManager>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			lm.LoadLevel(levelToLoad);
		}
	}
}
