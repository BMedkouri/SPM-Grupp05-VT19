using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionLoreObject : MonoBehaviour
{
   // public string myString;
   // public Text myText;
    public float fadeTime;
    public bool displayInfo;

    public LoreTextDialouge dialougeText;

    private bool hasClickedY = false;
    bool exit = false;

 

    public GameObject myButton1;
    public GameObject darkCanvas;

    void Start()
    {
     //   myText = GameObject.Find("Text").GetComponent<Text>();
  

         myButton1.SetActive(false);
        darkCanvas.SetActive(false);

 
    }
        
    void Update()
    {
 
        if(Input.GetKeyDown(KeyCode.Joystick1Button3) && displayInfo == true)
        {
            hasClickedY = true;

//            myText.text = myString;

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
         
}
