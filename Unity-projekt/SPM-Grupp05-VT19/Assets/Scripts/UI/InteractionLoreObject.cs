using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionLoreObject : MonoBehaviour
{
    public string myString;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;
  //  public Button myButton;

    public GameObject myButton1;
   
    void Start()
    {
        myText = GameObject.Find("Text").GetComponent<Text>();
        myText.color = Color.clear;

       // myButton = GetComponent<Button>();
        myButton1.SetActive(false);
       
    }
        
    void Update()
    {
        FadeText();
    }

    void OnMouseOver()
    {
        {
            displayInfo = true;
            //myButton.enabled = true;

            myButton1.SetActive(true);

        }
    }

    private void OnMouseExit()
    {
        displayInfo = false;
        myButton1.SetActive(false);
    }

    void FadeText()
    {
        if(displayInfo)
        {
            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
        }

        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
            
        }
    }
}
