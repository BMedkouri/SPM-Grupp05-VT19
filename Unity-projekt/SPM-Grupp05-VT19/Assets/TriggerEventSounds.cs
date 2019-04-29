using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventSounds : MonoBehaviour
{
    private AudioSource source;
    public AudioClip Meadow_Music;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Meadow")) //&& !source.isPlaying)
        {
            source.PlayOneShot(Meadow_Music);
            Debug.Log("Meadow!");
        }
    }

}
