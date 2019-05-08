//Author: Bilal El Medkouri

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEventListener : MonoBehaviour
{
    private void Start()
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
