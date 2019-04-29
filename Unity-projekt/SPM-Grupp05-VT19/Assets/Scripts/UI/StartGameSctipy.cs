using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameSctipy : MonoBehaviour
{

    [SerializeField] private string loadLevel;

    void Start()
    {        
    }

    void Update()
    {   
    }


    public void OnClickStartGame()
    {
        SceneManager.LoadScene(loadLevel);
    }
}
