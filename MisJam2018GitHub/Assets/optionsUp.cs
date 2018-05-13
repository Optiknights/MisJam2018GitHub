using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsUp : MonoBehaviour {

    public Animator startOptionsButtonsAnim;
    public GameObject music;
    public GameObject voice;

    public void OptionsUp()
    {
        Invoke("OptionUpDelay", 1f);
    }
    void OptionUpDelay()
    {
        startOptionsButtonsAnim.SetTrigger("gotoOptions");
        Invoke("MusicAndVoice", 2f);
    }
    void MusicAndVoice()
    {
        music.SetActive(true);
        voice.SetActive(true);
    }
}
