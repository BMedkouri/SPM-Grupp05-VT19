//Author: Bilal El Medkouri

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPrefabHandler : MonoBehaviour
{
    private void Awake()
    {
        SoundEventListener.AddSoundEvent();
    }

    private void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            SoundEventListener.SubtractSoundEvent();
            Destroy(gameObject);
        }
    }
}
