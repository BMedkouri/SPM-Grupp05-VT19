//Author: Bilal El Medkouri

using UnityEngine;

public class ParticleEventListener : EventListener<ParticleEvent>
{
    protected override void OnEvent(ParticleEvent particleEvent)
    {
        GameObject gameObject = Instantiate(particleEvent.ParticleSystem.gameObject, particleEvent.ParticleLocation, Quaternion.identity);
        Destroy(gameObject, particleEvent.ParticleSystem.main.duration);
    }
}
