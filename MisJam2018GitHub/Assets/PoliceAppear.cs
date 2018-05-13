using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAppear : MonoBehaviour {
    public GameObject UITool;
    public GameObject PoliceOfficer;
    public static bool FinalHardSlap;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(FinalHardSlap)
        {
			FinalHardSlap = false;
			StoryManager.AbsoluteGameState = GameState.PoliceStation;
            StartCoroutine(FinalSlapAnimation());
        }
	}

    IEnumerator FinalSlapAnimation()
    {
		yield return new WaitForSeconds (1);
        UITool.SetActive(true);
        //instantiate police
        Instantiate(PoliceOfficer, new Vector3(58.78f, 0.09f, 12.54f), Quaternion.identity);
        Instantiate(PoliceOfficer, new Vector3(58.46f, 0.09f, 15.73f), Quaternion.identity);
        Instantiate(PoliceOfficer, new Vector3(56.81f, 0.09f, 13.33f), Quaternion.identity);
        Instantiate(PoliceOfficer, new Vector3(56.65f, 0.09f, 14.94f), Quaternion.identity);
        yield return new WaitForSeconds(2);
        UITool.SetActive(false);

        
    }
}
