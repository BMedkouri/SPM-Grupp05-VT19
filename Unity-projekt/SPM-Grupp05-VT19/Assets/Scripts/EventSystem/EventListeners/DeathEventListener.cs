//Author: Bilal El Medkouri

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventListener : MonoBehaviour
{
    private void Start()
    {
        DeathEvent.RegisterListener(OnDeathEvent);
    }

    private void OnDestroy()
    {
        DeathEvent.UnregisterListener(OnDeathEvent);
    }

    private void OnDeathEvent(DeathEvent deathEvent)
    {
        DebugEvent debugEvent = new DebugEvent
        {
            DebugMessage = deathEvent.DyingGameObject.name + " has died."
        };
        debugEvent.FireEvent();

        SoundEvent soundEvent = new SoundEvent
        {
            AudioLocation = deathEvent.DyingGameObject.transform.position,
            AudioSource = deathEvent.DeathSound
        };
        soundEvent.FireEvent();

        ParticleEvent particleEvent = new ParticleEvent
        {
            ParticleLocation = deathEvent.DyingGameObject.transform.position,
            ParticleSystem = deathEvent.DeathParticle
        };
        particleEvent.FireEvent();

        Destroy(deathEvent.DyingGameObject);
    }
}