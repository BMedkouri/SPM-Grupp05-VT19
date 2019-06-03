using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameSctipy : MonoBehaviour
{

    [SerializeField] private int loadLevel;


    public void OnClickStartGame()
    {
        GameManager.Instance.ResetPlayerPrefs();
        SceneManager.LoadScene(loadLevel);
    }

    
}
