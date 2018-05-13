using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTriggers : MonoBehaviour {

    public int worldTriggerID;
    public StoryManager storyManager;
    public bool dialogueCurrent;

    // Use this for initialization
    void Start () {
        dialogueCurrent = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider WorldTrigger)
    {
        GameObject AIChar = WorldTrigger.gameObject;
        if (Input.GetKeyDown(KeyCode.X) && dialogueCurrent && worldTriggerID == 1)
        {
            StartCoroutine(WaitForDialogue());
            //storyManager.WorldEvent(worldTriggerID);
        }
    }

    IEnumerator WaitForDialogue()
    {
        yield return new WaitForSeconds(5);
        dialogueCurrent = true;
    }

}
