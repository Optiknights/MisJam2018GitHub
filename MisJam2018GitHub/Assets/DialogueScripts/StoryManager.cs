using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Story Manager tracks the quest line of the game. 
 * It also accepts input during dialogue options.
 * 
 * Individual states are described in GameStates.cs as enums.
 * 
 */

public class StoryManager : MonoBehaviour {

	public GameObject TextPanel;
	public Text Dialoguetextbox;
	bool DialogueMode;
	GameState AbsoluteGameState;
	DialogueExecuter dialogueExecuter;

	public Dialogue OpeningDialogue;
	public Dialogue FirstWomanDialogue;


	// Use this for initialization
	void Start () {
		Debug.Log ("Starting up story manager.");
		AbsoluteGameState = GameState.TalkingToFred;
		dialogueExecuter = new DialogueExecuter (TextPanel, Dialoguetextbox, OpeningDialogue, AbsoluteGameState);
	}
	
	// Update is called once per frame
	void Update () {

		// Currently using input key 'A' to advance dialogue. May change it to a different key, and add 1,2,3 for inputs later.

		if (Input.GetKeyUp (KeyCode.A)) {
			AbsoluteGameState = dialogueExecuter.Step ();
			Debug.Log (AbsoluteGameState);
		}

		// Input key 'B' triggers the start of the conversation with the First Woman. This is to be replaced by proximity trigger
		// or proximity + button press. 

		if (AbsoluteGameState == GameState.HeadingToFirstWoman && Input.GetKeyUp (KeyCode.B)) {
			AbsoluteGameState = GameState.TalkingToFirstWoman;
			dialogueExecuter = new DialogueExecuter (TextPanel, Dialoguetextbox, FirstWomanDialogue, AbsoluteGameState);
		}
		
	}

}
