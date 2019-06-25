using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPopupScript : MonoBehaviour
{

    [SerializeField] private GameObject controllerPopup;
    private void Awake()
    {

        controllerPopup.SetActive(false);
    }

    public void ControllerClick()
    {
        Debug.Log("You have clicked the button!");
        //set our bool to true
        controllerPopup.SetActive(true);
    }

    public void ControllerExit()
    {
        controllerPopup.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            if(controllerPopup.activeInHierarchy == true)
            {

                controllerPopup.SetActive(false);
            }
            else
            {

                controllerPopup.SetActive(true);
            }
        }   
    }

}
