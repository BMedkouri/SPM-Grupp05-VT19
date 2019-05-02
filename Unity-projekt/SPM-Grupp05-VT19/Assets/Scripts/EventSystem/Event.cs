using System;
using UnityEngine;

public abstract class Event<T> where T : Event<T>
{
    private bool hasFired;

    public delegate void EventListener(T info);
    public static event EventListener Listeners;

    public static void RegisterListener(EventListener listener)
    {
        Listeners += listener;
    }

    public static void UnregisterListener(EventListener listener)
    {
        Listeners -= listener;
    }

    public void FireEvent()
    {
        if (hasFired)
        {
            throw new Exception("This event has already fired, to prevent infinite loops, you can't refire an event.");
        }
        hasFired = true;

        Listeners?.Invoke(this as T);
    }
}

public class DebugEvent : Event<DebugEvent>
{
    public string DebugMessage;
}

public class DeathEvent : Event<DeathEvent>
{
    public GameObject DyingGameObject;
    public AudioSource DeathSound;
    public ParticleSystem DeathParticle;
}

public class SoundEvent : Event<SoundEvent>
{
    public Vector3 AudioLocation;
    public AudioSource AudioSource;
}

public class ParticleEvent : Event<ParticleEvent>
{
    public Vector3 ParticleLocation;
    public ParticleSystem ParticleSystem;
}