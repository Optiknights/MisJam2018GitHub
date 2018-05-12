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
	public Dialogue FirstWomanDialogue2;
	public Dialogue FuckOff;


	// Use this for initialization
	void Start () {

		AbsoluteGameState = GameState.HeadingToFred;
	}


	//To be accessed by game for trigger

	public void StartTalk(int charID, GameObject NPCObj)
	{
		Dialogue foundDialogue = FuckOff;

		switch (charID) {
		case 1:
			if (AbsoluteGameState == GameState.HeadingToFred) {
				AbsoluteGameState = GameState.TalkingToFred;
				foundDialogue = OpeningDialogue;
			} else {
				foundDialogue = FuckOff;
			}
			break;
		default:
			foundDialogue = FuckOff;
			break;

		}

		dialogueExecuter = new DialogueExecuter (TextPanel, Dialoguetextbox, foundDialogue, AbsoluteGameState, NPCObj);

		AbsoluteGameState = dialogueExecuter.Step ();

	}

	// Update is called once per frame
	void Update () {


		// Currently using input key 'x' to advance dialogue. May change it to a different key, and add 1,2,3 for inputs later.

		if (Input.GetKeyUp (KeyCode.C)) {
			AbsoluteGameState = dialogueExecuter.Step ();
			Debug.Log (AbsoluteGameState);
		}

		/*
		// Input key 'B' triggers the start of the conversation with the First Woman. This is to be replaced by proximity trigger
		// or proximity + button press. 

		if (AbsoluteGameState == GameState.HeadingToFirstWoman && Input.GetKeyUp (KeyCode.B)) {
			AbsoluteGameState = GameState.TalkingToFirstWoman;
			dialogueExecuter = new DialogueExecuter (TextPanel, Dialoguetextbox, FirstWomanDialogue, AbsoluteGameState);
		}

		// Input 'P' gives you a pizza slice. A second 'P' then triggers second dialogue with the woman.

		if (AbsoluteGameState == GameState.HeadingToBuyPizza && Input.GetKeyUp (KeyCode.P)) {
			AbsoluteGameState = GameState.ObtainedPizza;
		}

		if (AbsoluteGameState == GameState.ObtainedPizza && Input.GetKeyUp (KeyCode.P)) {
			AbsoluteGameState = GameState.TalkingToFirstWomanWithPizza;
			dialogueExecuter = new DialogueExecuter (TextPanel, Dialoguetextbox, FirstWomanDialogue2, AbsoluteGameState);

		}
		*/

		
	}

}
