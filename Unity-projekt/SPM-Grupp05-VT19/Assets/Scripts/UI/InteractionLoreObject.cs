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

    private bool hasClickedY = false;
    bool exit = false;

   // public GameObject darkCanvas;

    public GameObject myButton1;
    public GameObject darkCanvas;

    void Start()
    {
        myText = GameObject.Find("Text").GetComponent<Text>();
     //   myText.color = Color.clear;

         myButton1.SetActive(false);
        darkCanvas.SetActive(false);

    // bort   Image darkCanvas = gameObject.GetComponent<Image>();
    }
        
    void Update()
    {
      //  FadeText();

        if(Input.GetKeyDown(KeyCode.Joystick1Button3) && displayInfo == true)
        {
            hasClickedY = true;

            myText.text = myString;

            exit = true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2)) {
            hasClickedY = false;
            darkCanvas.SetActive(false);
        }




        if (hasClickedY)
        {
            darkCanvas.SetActive(true);
            myButton1.SetActive(false);
        }
        else
        {
            darkCanvas.SetActive(false);
        }
    }

    void OnMouseOver()
    {
        {
            displayInfo = true;
            myButton1.SetActive(true);

        }
    }

    private void OnMouseExit()
    {
        displayInfo = false;
        myButton1.SetActive(false);
    }


    /*
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

    */
}
