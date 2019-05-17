using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerTest : MonoBehaviour
{
    [SerializeField] private AudioClip WalkLoop;
    [SerializeField] private AudioClip dodge;
    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip music2;


    public void Update()
    { 



        if(Input.GetKeyDown(KeyCode.W) ) {
            audioManager.Instance.PlaySFX(WalkLoop);
        }
        
        if (Input.GetButtonDown("Xbox B"))
        {
            audioManager.Instance.PlaySFX(dodge);
         
        }

      
     
       
            
        
      
    }

}
