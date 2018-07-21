using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingObject : MonoBehaviour {

	public string sceneToTrigger;

	private InkManager inkManager;
	// Use this for initialization
	void Start () {
		inkManager = FindObjectOfType<InkManager>();
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		inkManager.TriggerScene(sceneToTrigger);
	}

	void OnTriggerExit2D(Collider2D collider){
		inkManager.RemoveChildren();
	}
	
}
