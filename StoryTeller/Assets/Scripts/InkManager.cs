using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkManager : MonoBehaviour {

	public TextAsset inkJSONasset;
	public Canvas canvas;
	public GameObject textPrefab;

	private Story story;
	private GameObject textDisplay;

	private DialogueManager dialogueManager;
	private LevelManager levelManager;

	string[] choices;
	// Use this for initialization
	void Start () {
		story = new Story(inkJSONasset.text);
		dialogueManager = FindObjectOfType<DialogueManager>();
		levelManager = FindObjectOfType<LevelManager>();
		BindFunctions();
		RefreshView();
	}

	//TODO: optimize so that only needed functions bind
	//maybe make an array of functions and can call externally to bind
	//use this to bind all functions for now
	void BindFunctions(){
		story.BindExternalFunction("load_scene",(string scene) =>{
			levelManager.LoadLevel(scene);
		});
	}
	
	void RefreshView(){
		//clears the view
		RemoveChildren();
		while(story.canContinue){
			string text = story.Continue().Trim();
			CreateContentView(text);
		}
		if(story.currentChoices.Count > 0){
			CreateDialogueMenu();
		}
	}

	public void RemoveChildren(){
		int childCount = canvas.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			GameObject.Destroy (canvas.transform.GetChild (i).gameObject);
		}
	}

	void CreateContentView(string text){
		Debug.Log("creating content");
		textDisplay = Instantiate(textPrefab) as GameObject;
		textDisplay.transform.SetParent(canvas.transform, false);
		textDisplay.GetComponent<Text>().text = text;
	}

	void CreateDialogueMenu(){
		choices = new string[story.currentChoices.Count];

		for(int i = 0; i < story.currentChoices.Count; i++){

			Choice choice = story.currentChoices[i];
			choices[i] = choice.text.Trim();
		}

		dialogueManager.RenderChoices(choices);

	}

	public void ChoosePath(int choiceIndex){
		story.ChooseChoiceIndex(choiceIndex);
		RefreshView();
	}

	public void TriggerScene(string scene){
		story.ChoosePathString(scene);
		RefreshView();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
