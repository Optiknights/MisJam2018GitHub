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
	GameObject NPCObj;
	GameObject NPC;

	string slapQuality;

	public DialogueExecuter(GameObject inTextPanel, Text dialogueTextBox, Dialogue inDialogue, GameState inGameState, GameObject NPCobject, GameObject inNPC)
	{
		Debug.Log ("Spinning up DialogueExecuter.");
		textPanel = inTextPanel;
		textPanel.SetActive (true);
		dialogueTextBox.text = "Testing";
		dialogueTextUI = dialogueTextBox;
		dialogue = inDialogue;
		index = 0;
		gameState = inGameState;
		NPCObj = NPCobject;
		NPC = inNPC;
		slapQuality = "NoSlap";
	}

    public DialogueExecuter(GameObject inTextPanel, Text dialogueTextBox, Dialogue inDialogue, GameState inGameState)
    {
        Debug.Log("Spinning up DialogueExecuter.");
        textPanel = inTextPanel;
        textPanel.SetActive(true);
        dialogueTextBox.text = "*Looking around*";
        dialogueTextUI = dialogueTextBox;
        dialogue = inDialogue;
        index = 0;
        gameState = inGameState;
        slapQuality = "NoSlap";
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

			if (dialogue.StateOfGameAfterDialogue != GameState.NoChange) {
				gameState = dialogue.StateOfGameAfterDialogue;
			}
			textPanel.SetActive (false);
			if (slapQuality != "NoSlap") {
				
				Animator npcanim = NPC.GetComponent<Animator> ();
				npcanim.SetTrigger ("Slap");

                AudioSource playerSource = NPC.GetComponent<AudioSource>();
                playerSource.Play();


                if(StoryManager.AbsoluteGameState == GameState.HeadingToSecondWoman || StoryManager.AbsoluteGameState == GameState.HeadingToProstitute)
                {
                    npcanim.SetBool("LastSlap", true);
                }

				//StoryManager.instance.StartChileCoroutine (hitter ());

				Animator npcanimator = NPCObj.GetComponent<Animator> ();
				npcanimator.SetTrigger (slapQuality);

				StoryManager.HandCount++;

                Debug.Log(StoryManager.AbsoluteGameState);
				//StartCoroutine (hitter ());
                if(StoryManager.AbsoluteGameState == GameState.TalkingToProstituteWithCash)
                {
                    Debug.Log("settoTrue");
                    PoliceAppear.FinalHardSlap = true;
                }
				

			}
		}

		index++;
			
		return gameState;
	}

	IEnumerable hitter(){
		yield return new WaitForSeconds (2);
		Animator npcanimator = NPCObj.GetComponent<Animator> ();
		npcanimator.SetTrigger (slapQuality);
	}

	public void SetSlap(string inSlap)
	{
		slapQuality = inSlap;
	}

}
