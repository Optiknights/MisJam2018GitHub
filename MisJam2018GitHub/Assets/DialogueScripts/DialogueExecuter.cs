using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Runs through the dialogue, executing it one line at a time.
 *
 */

public class DialogueExecuter {

	Text dialogueTextUI;
	Dialogue dialogue;
	int index;
	GameState gameState;
	GameObject textPanel;

	public DialogueExecuter(GameObject inTextPanel, Text dialogueTextBox, Dialogue inDialogue, GameState inGameState)
	{
		Debug.Log ("Spinning up DialogueExecuter.");
		textPanel = inTextPanel;
		textPanel.SetActive (true);
		dialogueTextBox.text = "Testing";
		dialogueTextUI = dialogueTextBox;
		dialogue = inDialogue;
		index = 0;
		gameState = inGameState;
		Step ();
	}

	public GameState Step()
	{
		Debug.Log ("Into Step.");
		Debug.Log ("index: " + index + " list count: " + dialogue.Speech.Count + "  Line:");

		if (index < dialogue.Speech.Count) {
			dialogueTextUI.text = dialogue.Speech[index];
			dialogueTextUI.text = dialogueTextUI.text.Replace("\\n", "\n");
			Debug.Log (dialogue.Speech [index]);

		}

		if (index == (dialogue.Speech.Count)) {
			gameState = dialogue.StateOfGameAfterDialogue;
			textPanel.SetActive (false);
		}

		index++;
			
		return gameState;
	}
}
