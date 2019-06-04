using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaSounds : MonoBehaviour
{

    private AudioSource source;
    public AudioClip clip;

  

    void Start()
    {
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Meadow"))
        {
           
            source.PlayOneShot(clip);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Meadow"))
        {
            source.Pause();
        }
    }

}
