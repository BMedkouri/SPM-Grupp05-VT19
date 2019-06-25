using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonScript : MonoBehaviour
{

    public void ClickQuitGame()
    {

        Application.Quit();

        Debug.Log("Quitting game");
    }
}
