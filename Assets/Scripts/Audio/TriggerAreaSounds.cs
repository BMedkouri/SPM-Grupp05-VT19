using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaSounds : MonoBehaviour
{

    private AudioSource source;
    public AudioClip clip;
    public AudioClip bossMusic;

  

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

        if(other.gameObject.CompareTag("BossRoom"))
        {
            source.PlayOneShot(bossMusic);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Meadow"))
        {
            source.Pause();
        }

        if (other.gameObject.CompareTag("BossRoom"))
        {
            source.Pause();
        }
    }

}
