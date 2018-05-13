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
	public static GameState AbsoluteGameState;

	public GameObject PCobj;

	/*
	public AIBehavior FredBehav;
	public AIBehavior LisaBehav;
	public AIBehavior TinaBehav;
	public AIBehavior ChrystalBehav;
	*/

	public GameObject Fred;
	public GameObject Lisa;
	public GameObject Tina;
	public GameObject Chrystal;

	bool DialogueMode;
	DialogueExecuter dialogueExecuter;

	public Dialogue OpeningDialogue;
	public Dialogue FirstWomanDialogue;
	public Dialogue FirstWomanDialogue2;
	public Dialogue SecondWomanDialogue;
	public Dialogue SecondWomanDialogue2;
	public Dialogue ProstituteDialogue;
	public Dialogue ProstituteDialogue2;
	public Dialogue FuckOff;
    public Dialogue PizzaShop;
    public Dialogue ChineseShop;
    public Dialogue ATM;


	// Use this for initialization
	void Start () {

		AbsoluteGameState = GameState.HeadingToFred;
		//AbsoluteGameState = GameState.ObtainedCash;
	}


	//To be accessed by game for trigger
    public void WorldEvent(int worldTriggerID)
    {
		Debug.Log ("Triggered WorldEvent");
        Dialogue foundDialogue = FuckOff;

        switch (worldTriggerID)
        {
            case 1:
			if (AbsoluteGameState == GameState.HeadingToBuyPizza || AbsoluteGameState == GameState.ObtainedPizza)
                {
                    AbsoluteGameState = GameState.ObtainedPizza;
                    foundDialogue = PizzaShop;
                }
                break;
            case 2:
			if (AbsoluteGameState == GameState.HeadingToGetChinese || AbsoluteGameState == GameState.ObtainedChinese)
                {
                    AbsoluteGameState = GameState.ObtainedChinese;
                    foundDialogue = ChineseShop;
                }
                break;
            case 3:
			if (AbsoluteGameState == GameState.HeadingToATM || AbsoluteGameState == GameState.ObtainedCash)
                {
                    AbsoluteGameState = GameState.ObtainedCash;
                    foundDialogue = ATM;
                }
                break;
            default:
                foundDialogue = FuckOff;
                break;
        }

		Debug.Log ("Which dialogue using? "  + foundDialogue.name);

		dialogueExecuter = new DialogueExecuter(TextPanel, Dialoguetextbox, foundDialogue, AbsoluteGameState);
        //AbsoluteGameState = dialogueExecuter.Step();
        
    }



    public void StartTalk(int charID, GameObject NPCObj)
	{
		Dialogue foundDialogue = FuckOff; //Default option if nothing else matches.
		GameObject NPC = Lisa;
		Debug.Log ("Triggered StartTalk.");

		switch (charID) {
		case 1:
			NPC = Fred;
			if (AbsoluteGameState == GameState.HeadingToFred) {
				AbsoluteGameState = GameState.TalkingToFred;
				foundDialogue = OpeningDialogue;
			}
			break;

		case 2:
			NPC = Lisa;
			if (AbsoluteGameState == GameState.HeadingToFirstWoman) {
				AbsoluteGameState = GameState.TalkingToFirstWoman;
				foundDialogue = FirstWomanDialogue;
			}
			if (AbsoluteGameState == GameState.ObtainedPizza) {
				AbsoluteGameState = GameState.TalkingToFirstWomanWithPizza;
				foundDialogue = FirstWomanDialogue2;
			}
			break;

		case 3:
			NPC = Tina;
			if (AbsoluteGameState == GameState.HeadingToSecondWoman) {
				AbsoluteGameState = GameState.TalkingToSecondWoman;
				foundDialogue = SecondWomanDialogue;
			}
			if (AbsoluteGameState == GameState.ObtainedChinese) {
				AbsoluteGameState = GameState.TalkingToSecondWomanWithChinese;
				foundDialogue = SecondWomanDialogue2;
			}
			break;

		case 4:
			NPC = Chrystal;
			if (AbsoluteGameState == GameState.HeadingToProstitute) {
				AbsoluteGameState = GameState.TalkingToProstitute;
				foundDialogue = ProstituteDialogue;
			}
			if (AbsoluteGameState == GameState.ObtainedCash) {
				AbsoluteGameState = GameState.TalkingToProstituteWithCash;
				foundDialogue = ProstituteDialogue2;
			}
			break;

		default:
			foundDialogue = FuckOff;
			break;
		}

		Debug.Log ("Which dialogue using? "  + foundDialogue.name);

		dialogueExecuter = new DialogueExecuter (TextPanel, Dialoguetextbox, foundDialogue, AbsoluteGameState, PCobj, NPC);

		AbsoluteGameState = dialogueExecuter.Step ();

	}

	// Update is called once per frame
	void Update () {

		/*if (AbsoluteGameState == GameState.KnockedOut) {
			PoliceAppear.FinalHardSlap = true;
		}*/

		if (Input.GetKeyUp (KeyCode.Alpha1) || Input.GetKeyUp (KeyCode.Keypad1)) {
			CheckSlapList (1);
			AbsoluteGameState = dialogueExecuter.Step ();
			Debug.Log (AbsoluteGameState);
		}

		if (Input.GetKeyUp (KeyCode.Alpha2) || Input.GetKeyUp (KeyCode.Keypad2)) {
			CheckSlapList (2);
			AbsoluteGameState = dialogueExecuter.Step ();
			Debug.Log (AbsoluteGameState);
		}

		if (Input.GetKeyUp (KeyCode.Alpha3) || Input.GetKeyUp (KeyCode.Keypad3)) {
			CheckSlapList (3);
			AbsoluteGameState = dialogueExecuter.Step ();
			Debug.Log (AbsoluteGameState);
		}
			

		// Currently using input key 'c' to advance dialogue. May change it to a different key, and add 1,2,3 for inputs later.

		/* if (Input.GetKeyUp (KeyCode.C)) {
			AbsoluteGameState = dialogueExecuter.Step ();
			Debug.Log (AbsoluteGameState);
		}


		
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

		if ((Input.GetKeyUp (KeyCode.Escape))) {
			Application.Quit ();
		}

		
	}

	public void StartChildCoroutine(IEnumerator coroutineMethod)
	{
		StartCoroutine(coroutineMethod);
	}

	void SetSoftSlap()
	{
		dialogueExecuter.SetSlap ("SoftSlap");
	}

	void SetHardSlap()
	{
		dialogueExecuter.SetSlap ("HardSlap");
	}

	void SetNoSlap()
	{
		dialogueExecuter.SetSlap ("NoSlap"); //not currently an existing animation trigger.
	}

	void CheckSlapList(int num){
		
		switch (AbsoluteGameState) {

			case GameState.TalkingToFred:
				SetNoSlap ();
				break;
				
			case GameState.TalkingToFirstWoman:
				if (num == 1) {
					SetSoftSlap ();
				} else {
					SetHardSlap ();
				}
				break;

			case GameState.TalkingToFirstWomanWithPizza:
				if (num == 1) {
					SetSoftSlap ();
				} else {
					SetHardSlap ();
				}
				break;

			case GameState.TalkingToSecondWoman:
				if (num == 1) {
					SetSoftSlap ();
				} else {
					SetHardSlap ();
				}
				break;

			case GameState.TalkingToSecondWomanWithChinese:
					SetHardSlap ();
				break;

			case GameState.TalkingToProstitute:
				SetNoSlap ();
				break;

			case GameState.TalkingToProstituteWithCash:
				SetHardSlap ();
				break;

		default:
			SetNoSlap ();
				break;
		}
	}


}
