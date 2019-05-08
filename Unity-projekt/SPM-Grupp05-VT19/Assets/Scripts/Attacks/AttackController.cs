//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a superclass for Attacks.
/// It holds attributes for the name, damage, sound and particle oeffects, for an attack.
/// When called upon from AttackHandler, it will fire off events and check for collisions.
/// We currently have two different types of attacks - in the sense that we have two different collider shapes for attacks - which are Box (Collider) Attacks, and Sphere (Collider) Attacks.
/// 
/// The logic for collision is inside of BoxAttackController and SphereAttackController, but it works in basically the same way.
/// </summary>
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
