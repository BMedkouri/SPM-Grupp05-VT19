using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLeaf : MonoBehaviour
{
    private AudioSource[] sources;
    public AudioClip leafs;
    public AudioClip leafFalling;
    public float minDelay;
    public float maxDelay;


    void Start()
    {
        sources = GetComponents<AudioSource>();
        sources[0].clip = leafs;
        sources[1].clip = leafFalling;
    }

    // Update is called once per frame
    void Update()
    {
        if(!sources[0].isPlaying)
        {
            float d = Random.Range(minDelay, maxDelay);
            sources[0].PlayDelayed(d);
        }

        if (!sources[1].isPlaying)
        {
            float d = Random.Range(minDelay, maxDelay);
            sources[1].PlayDelayed(d);
        }
    }
}
