using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerCount : MonoBehaviour
{
    public Text countText;
    private int count;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("flower"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetFlowerCount();
        }
    }
    public void SetFlowerCount()
    {
        countText.text = "" + count.ToString();
    }
}