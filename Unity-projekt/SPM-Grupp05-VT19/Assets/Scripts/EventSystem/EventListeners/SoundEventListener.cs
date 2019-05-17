//Author: Bilal El Medkouri

using UnityEngine;

public class SoundEventListener : EventListener<SoundEvent>
{
    [Header("Settings")]
    [SerializeField] private int maxSimultaneousSoundEvents;
    private static int currentSimultaneousSoundEvents;


    private void Awake()
    {
        currentSimultaneousSoundEvents = 0;
    }

    protected override void OnEvent(SoundEvent soundEvent)
    {
        if (currentSimultaneousSoundEvents < maxSimultaneousSoundEvents)
        {
            GameObject gameObject = Instantiate(soundEvent.AudioSource.gameObject, soundEvent.AudioLocation, Quaternion.identity);
            Destroy(gameObject, soundEvent.AudioSource.clip.length);
        }
        else
        {
            DebugEvent debugEvent = new DebugEvent("Maximum amount of sound events reached. " + maxSimultaneousSoundEvents + " audio clips are currently playing.");
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