using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] private int loadLevel;


    public void OnClickStartGame()
    {
        SceneManager.LoadScene(loadLevel);

        Debug.Log("Main menu click");
    }
}
