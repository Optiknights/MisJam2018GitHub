using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour {

	public GameObject TextPanel;
	public Text Dialoguetextbox;
	bool DialogueMode;
	GameState AbsoluteGameState;
	DialogueExecuter dialogueExecuter;

	public Dialogue OpeningDialogue;


	// Use this for initialization
	void Start () {
		Debug.Log ("Starting up story manager.");
		AbsoluteGameState = GameState.TalkingToFred;
		dialogueExecuter = new DialogueExecuter (TextPanel, Dialoguetextbox, OpeningDialogue, AbsoluteGameState);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.A)) {
			AbsoluteGameState = dialogueExecuter.Step ();
			Debug.Log (AbsoluteGameState);
		}
		
	}

}
