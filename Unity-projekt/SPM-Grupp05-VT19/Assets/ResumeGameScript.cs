using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameScript : MonoBehaviour
{

    [SerializeField] private GameObject popupMenu;

    public void ResumeGameClick()
    {
        Debug.Log("You have clicked the button!");
        //set our bool to true
        popupMenu.SetActive(false);
    }
}
