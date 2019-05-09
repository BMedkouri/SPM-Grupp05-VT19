using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{

    [SerializeField] protected string healName;
    [SerializeField] protected float healAmount;
    [SerializeField] protected AudioSource soundEffect;
    [SerializeField] protected ParticleSystem particleEffect;

    public void TriggerParticleEvent()
    {
        ParticleEvent particleEvent = new ParticleEvent
        {
            ParticleLocation = transform.position,
            ParticleSystem = particleEffect
        };
        particleEvent.FireEvent();
    }

    public void TriggerSoundEvent()
    {
        SoundEvent soundEvent = new SoundEvent
        {
            AudioLocation = transform.position,
            AudioSource = soundEffect
        };
        soundEvent.FireEvent();
    }

    public void HealObject()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthComponent>().RecoverHealth(healAmount);
    }
}
