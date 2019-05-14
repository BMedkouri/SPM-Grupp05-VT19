//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using System;
using UnityEngine;

public abstract class EventListener : MonoBehaviour
{
    protected virtual void Awake() { }

    protected virtual void Start() { }

    protected virtual void OnDestroy() { }

    protected virtual void OnEvent(Event soundEvent)
    {
        if (currentSimultaneousSoundEvents < maxSimultaneousSoundEvents)
        {
            Instantiate(soundEvent.AudioSource, soundEvent.AudioLocation, Quaternion.identity);
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
}

public class ParticleEventListener : EventListener
{
    private override void Start()
    {
        ParticleEvent.RegisterListener(OnParticleEvent);
    }

    private void OnDestroy()
    {
        ParticleEvent.UnregisterListener(OnParticleEvent);
    }

    private void OnParticleEvent(ParticleEvent particleEvent)
    {
        Instantiate(particleEvent.ParticleSystem, particleEvent.ParticleLocation, Quaternion.identity);
    }
}