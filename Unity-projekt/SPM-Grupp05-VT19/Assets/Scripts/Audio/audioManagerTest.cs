using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerTest : MonoBehaviour
{
    [SerializeField] private AudioClip WalkLoop;
    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip music2;


    public void Update()
    { 
        if(RunState.FindObjectOfType<RunState>())
        {
         // audioManager.Instance.PlaySFX(WalkLoop, 1);
            audioManager.Instance.PlayLoop(WalkLoop, 1);
        }
        
        


        /*
        if (Input.GetKeyDown(KeyCode.E)) // Play normal sfx function
        {
            audioManager.Instance.PlaySFX(buttonClickSFX, 1); //Buttonclick sfx AND volume
        }

        if (Input.GetKeyDown(KeyCode.L)) // Play normal sfx function
        {
            audioManager.Instance.PlayMusic(music1); //Play the second track
        }
        */
    }

}
