using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] private string loadLevel;


    public void OnClickStartGame()
    {
        SceneManager.LoadScene(loadLevel);

        Debug.Log("Main menu click");
    }
}
