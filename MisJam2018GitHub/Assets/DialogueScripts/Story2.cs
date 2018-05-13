using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Story Manager tracks the quest line for scene 2. 
 * It also accepts input during dialogue options.
 * 
 */

public class Story2 : MonoBehaviour {

	public GameObject TextPanel;
	public Text Dialoguetextbox;
	public static GameState AbsoluteGameState;
	public static int NodeCounter;

	public GameObject PCObj;



	public GameObject Fred;
	public GameObject Gina;

	bool DialogueMode;
	bool gameOver;
	DialogueExecuter dialogueExecuter;

	public Dialogue FinalDialogue;


	// Use this for initialization
	void Start () {

		//AbsoluteGameState = GameState.Node1;
		//AbsoluteGameState = GameState.ObtainedCash;
		gameOver = false;
		NodeCounter = 1;
		dialogueExecuter = new DialogueExecuter (TextPanel, Dialoguetextbox, FinalDialogue, AbsoluteGameState, PCObj, Gina);
		dialogueExecuter.Step ();
	}


	// Update is called once per frame
	void Update () {

		/*if (AbsoluteGameState == GameState.KnockedOut) {
			PoliceAppear.FinalHardSlap = true;
		}*/

		if ((Input.GetKeyUp (KeyCode.Alpha1) || Input.GetKeyUp (KeyCode.Keypad1)) && !gameOver) {
			SetNoSlap ();
			if (NodeCounter == 13 || NodeCounter == 15) {
				LossCondition ();
			} else if (NodeCounter == 16) {
				WinCondition ();
			} else {
				AbsoluteGameState = dialogueExecuter.Step ();
			}
			Debug.Log (AbsoluteGameState);
			NodeCounter++;
			Debug.Log (NodeCounter);
		}

		if ((Input.GetKeyUp (KeyCode.Alpha2) || Input.GetKeyUp (KeyCode.Keypad2)) && !gameOver) {
			SetNoSlap ();
			if (NodeCounter == 10) {
				LossCondition ();
			} else if (NodeCounter == 16) {
				WinCondition ();
			} else {
				AbsoluteGameState = dialogueExecuter.Step ();
			}

			Debug.Log (AbsoluteGameState);
			NodeCounter++;
			Debug.Log (NodeCounter);

		}

		if ((Input.GetKeyUp (KeyCode.Alpha3) || Input.GetKeyUp (KeyCode.Keypad3)) && !gameOver) {
			SetNoSlap ();
			if (NodeCounter == 16) {
				WinCondition ();
			} else {
				AbsoluteGameState = dialogueExecuter.Step ();
			}
			Debug.Log (AbsoluteGameState);
			NodeCounter++;
			Debug.Log (NodeCounter);

		}

		if ((Input.GetKeyUp (KeyCode.Escape))) {
			Application.Quit ();
		}



	}

	void LossCondition()
	{
		gameOver = true;

		Animator npcanim = Gina.GetComponent<Animator> ();
		npcanim.SetTrigger ("Slap");

		AudioSource playerSource = Gina.GetComponent<AudioSource>();
		playerSource.Play();

		Animator pcanimator = PCObj.GetComponent<Animator> ();
		pcanimator.SetTrigger ("HardSlap");

		Dialoguetextbox.color = Color.red;
		Dialoguetextbox.fontStyle = FontStyle.Bold;
		Dialoguetextbox.text = "You Died!";
	}

	void WinCondition()
	{
		gameOver = true;

		Dialoguetextbox.color = Color.blue;
		Dialoguetextbox.fontStyle = FontStyle.Bold;


		Dialoguetextbox.text = "You won!";
	}



	void SetNoSlap()
	{
		dialogueExecuter.SetSlap ("NoSlap"); 
	}



}
