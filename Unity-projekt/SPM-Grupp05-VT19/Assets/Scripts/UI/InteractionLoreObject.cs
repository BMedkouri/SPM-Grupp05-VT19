using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionLoreObject : MonoBehaviour
{
    public bool displayInfo;
    private bool hasClickedY = false;

    public TextMeshProUGUI textDisplay;


    public GameObject myButton1;
    public GameObject darkCanvas;
    public GameObject loreText;




    void Start()
    {
        myButton1.SetActive(false);
        darkCanvas.SetActive(false);
        loreText.SetActive(false);

    }

    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Joystick1Button3) && displayInfo == true)
        {
            hasClickedY = true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            hasClickedY = false;
            darkCanvas.SetActive(false);
        }

        if (hasClickedY)
        {
            darkCanvas.SetActive(true);
            loreText.SetActive(true);
            myButton1.SetActive(false);
        }
        else
        {
            darkCanvas.SetActive(false);
            loreText.SetActive(false);
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
