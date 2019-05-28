//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

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
    public string DebugMessage { get; }

    public DebugEvent(string debugMessage)
    {
        DebugMessage = debugMessage;
    }
}

public class DamageEvent : Event<DamageEvent>
{
    public float Damage { get; }
    public GameObject InstigatorGameObject { get; }
    public GameObject DamagedGameObject { get; }

    public DamageEvent(float damage, GameObject instigatorGameObject, GameObject damagedGameObject)
    {
        Damage = damage;
        InstigatorGameObject = instigatorGameObject;
        DamagedGameObject = damagedGameObject;
    }
}

public class HitEvent : Event<HitEvent>
{
    public ContactPoint HitContactPoint { get; }

    public HitEvent(ContactPoint hitContactPoint)
    {
        HitContactPoint = hitContactPoint;
    }
}

public class DeathEvent : Event<DeathEvent>
{
    public GameObject DyingGameObject { get; }

    public DeathEvent(GameObject dyingGameObject)
    {
        DyingGameObject = dyingGameObject;
    }
}

public class SoundEvent : Event<SoundEvent>
{
    public Vector3 AudioLocation { get; }
    public AudioSource AudioSource { get; }

    public SoundEvent(Vector3 audioLocation, AudioSource audioSource)
    {
        AudioLocation = audioLocation;
        AudioSource = audioSource;
    }
}

public class ParticleEvent : Event<ParticleEvent>
{
    public Vector3 ParticleLocation { get; }
    public ParticleSystem ParticleSystem { get; }

    public ParticleEvent(Vector3 particleLocation, ParticleSystem particleSystem)
    {
        ParticleLocation = particleLocation;
        ParticleSystem = particleSystem;
    }
}

public class ChangeLevelEvent : Event<ChangeLevelEvent>
{
    public int Level { get; }
    public Vector3 PlayerLocation { get; }

    public ChangeLevelEvent(int level, Vector3 playerLocation)
    {
        Level = level;
        PlayerLocation = playerLocation;
    }
}

public class SaveGameEvent : Event<SaveGameEvent>
{
    public Vector3 Position { get; }

    public SaveGameEvent(Vector3 position)
    {
        Position = position;
    }
}

public class CheckpointEvent : Event<CheckpointEvent>
{
    public int CheckpointNumber { get; }

    public CheckpointEvent(int checkpointNumber)
    {
        CheckpointNumber = checkpointNumber;
    }
}