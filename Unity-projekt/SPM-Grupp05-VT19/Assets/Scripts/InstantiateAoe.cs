using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAoe : MonoBehaviour
{
    [SerializeField] private GameObject Aoe;
    [SerializeField] private ParticleSystem particleSystem;
    public void InstantiateAOE()
    {
        if (particleSystem != null)
        {
            ParticleEvent particle = new ParticleEvent(transform.position, particleSystem);
            particle.FireEvent();
        }
        GameObject attack = Instantiate(Aoe, transform);
        Destroy(attack, 0.1f);
    }
}
