using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {


	public GameObject[] choicePrefab;
	public Canvas canvas;

	private InkManager ink;
	private GameObject choiceDisplay;

	private GameObject[] activeChoices;
	// Use this for initialization
	void Start () {
		ink = FindObjectOfType<InkManager>();
	}
	
	private int activeChoiceIndex;
	private int totalChoices;
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.DownArrow)){
			if( activeChoiceIndex < totalChoices -1 ){ 
				activeChoiceIndex++;
				HighlightChoice(activeChoiceIndex);
			 }
		}

		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if( activeChoiceIndex > 0 ){ 
				activeChoiceIndex--;
				HighlightChoice(activeChoiceIndex);
			 }
		}

		if(Input.GetKeyDown("space") || Input.GetKeyDown("return")){
			ink.ChoosePath(activeChoiceIndex);
		}

		
	}

	private void HighlightChoice(int choice){
		for(int i =0; i < activeChoices.Length; i++){
			activeChoices[i].GetComponent<Text>().color = Color.white;
		}
		activeChoices[choice].GetComponent<Text>().color = Color.green;
	}




	public void RenderChoices(string[] choiceArray){

		activeChoiceIndex = 0;
		totalChoices = choiceArray.Length;

		activeChoices = new GameObject[choiceArray.Length];
		
		for(int i =0; i < choiceArray.Length; i++){
			choiceDisplay = Instantiate(choicePrefab[i]) as GameObject;
			choiceDisplay.transform.SetParent(canvas.transform, false);
			choiceDisplay.GetComponent<Text>().text = choiceArray[i];

			activeChoices[i] = choiceDisplay;
		}

		HighlightChoice(activeChoiceIndex);
	}
}
