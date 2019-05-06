using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] protected LayerMask collisionLayerMask;

    [SerializeField] protected string attackName;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected AudioSource attackSoundEffect;
    [SerializeField] protected ParticleSystem attackParticleEffect;

    public void TriggerParticleEvent()
    {
        ParticleEvent particleEvent = new ParticleEvent
        {
            ParticleLocation = transform.position,
            ParticleSystem = attackParticleEffect
        };
        particleEvent.FireEvent();
    }

    public void TriggerSoundEvent()
    {
        SoundEvent soundEvent = new SoundEvent
        {
            AudioLocation = transform.position,
            AudioSource = attackSoundEffect
        };
        soundEvent.FireEvent();
    }

    public virtual void CheckForCollision() { }
}
