using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour {


    public bool isSlapping;
    public int characterID;
    public bool dialogueCurrent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        //Include a trigger for when slap occurs.

	}

    public void AISlap(GameObject AICharacter)
    {
        Animator aiAnim = AICharacter.GetComponent<Animator>();
        if (isSlapping)
        {
            Debug.Log("CharacterSlap");
            aiAnim.SetTrigger("Slap");
            isSlapping = false;
        }
    }

    public void AISlap()
    {
        Animator aiAnim = this.gameObject.GetComponent<Animator>();
        if (isSlapping)
        {
            Debug.Log("CharacterSlap");
            aiAnim.SetTrigger("Slap");
            isSlapping = false;
        }
    }

    void OnTriggerStay(Collider AITrigger)
    {
        GameObject AIChar = AITrigger.gameObject;
        if (Input.GetKeyDown(KeyCode.X) && dialogueCurrent)
        {
            dialogueCurrent = false;
            StartCoroutine(WaitForDialogue());
            //gamestate.StartTalk(characterID, AIChar);
        }
    }

    IEnumerator WaitForDialogue()
    {
        yield return new WaitForSeconds(5);
        dialogueCurrent = true;
    }
}
