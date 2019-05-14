//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using System;
using UnityEngine;

//SE ÖVER DETTA
public abstract class EventListener<EventType> where EventType : Event<EventType>
{
    protected virtual void Start()
    {
        Event<EventType>.RegisterListener(OnEvent);
    }

    protected virtual void OnDestroy()
    {
        Event<EventType>.UnregisterListener(OnEvent);
    }

    protected virtual void OnEvent(Event<EventType> eventType){ }
}

public class ParticleEventListener : EventListener<ParticleEvent>
{
    /*protected override void OnEvent(ParticleEvent particleEvent)
    {
        UnityEngine.Object.Instantiate(particleEvent.ParticleSystem, particleEvent.ParticleLocation, Quaternion.identity);
    }*/
}