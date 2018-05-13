using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLocation : MonoBehaviour {

    Vector3 FirstGirlLocation = new Vector3(64.14f, 6.41f, 47.94f);
    Vector3 SecondGirlLocation = new Vector3(29.37f, 6.41f, 58.15f);
    Vector3 LastGirlLocation = new Vector3(58.46f, 6.41f, 13.82f);

    // Use this for initialization
    void Start () {
        this.gameObject.transform.position = FirstGirlLocation;
    }
	
	// Update is called once per frame
	void Update () {
		if(GameState.HeadingToSecondWoman == StoryManager.AbsoluteGameState)
        {
            this.gameObject.transform.position = SecondGirlLocation;
        }
        if (GameState.HeadingToProstitute == StoryManager.AbsoluteGameState)
        {
            this.gameObject.transform.position = LastGirlLocation;
        }
    }
}
