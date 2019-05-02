using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEventListener : MonoBehaviour
{
    [SerializeField] private int maxSimultaneousSoundEvents;
    private static int currentSimultaneousSoundEvents;

    private void Awake()
    {
        currentSimultaneousSoundEvents = 0;
    }

    private void Start()
    {
        SoundEvent.RegisterListener(OnSoundEvent);
    }

    private void OnDestroy()
    {
        SoundEvent.UnregisterListener(OnSoundEvent);
    }

    private void OnSoundEvent(SoundEvent soundEvent)
    {
        if (currentSimultaneousSoundEvents < maxSimultaneousSoundEvents)
        {
            Instantiate(soundEvent.AudioSource, soundEvent.AudioLocation, Quaternion.identity);
            //AudioSource.PlayClipAtPoint(soundEvent.AudioClip, soundEvent.AudioLocation);
        }
        else
        {
            DebugEvent debugEvent = new DebugEvent
            {
                DebugMessage = "Maximum amount of sound events reached. " + maxSimultaneousSoundEvents + " audio clips are currently playing."
            };
            debugEvent.FireEvent();
        }
    }

    public static void AddSoundEvent()
    {
        currentSimultaneousSoundEvents++;
    }

    public static void SubtractSoundEvent()
    {
        currentSimultaneousSoundEvents--;
    }
}