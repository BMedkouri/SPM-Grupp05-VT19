using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    //RunState playerScript;

    // Start is called before the first frame update
    private AudioSource PlayerSource;
    public AudioClip runStepsMarble;
    void Start()
    {
        //    playerScript = GetComponent<RunState>();
        PlayerSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !PlayerSource.isPlaying) 
        {
            PlayerSource.Play(0);
        }
    }
}
