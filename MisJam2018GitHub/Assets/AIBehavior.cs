using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour {


    public bool isSlapping;
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
}
