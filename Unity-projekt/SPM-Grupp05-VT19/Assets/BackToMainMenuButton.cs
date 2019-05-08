using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenuButton : MonoBehaviour
{

    [SerializeField] private string loadLevel;

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            SceneManager.LoadScene(loadLevel);
        }

        
    }
}
