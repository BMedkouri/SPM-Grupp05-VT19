using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;

    public void InstansiateParticles()
    {
        ParticleEvent particle = new ParticleEvent(transform.position, particleSystem);
        particle.FireEvent();
    }
}
