using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAoe : MonoBehaviour
{
    [SerializeField] private GameObject Aoe;
    [SerializeField] private ParticleSystem particleSystem;
    GameObject attack;
    public void InstantiateAOE()
    {
        Debug.Log(transform.tag + " Enemy tag");
        if (particleSystem != null)
        {
            ParticleEvent particle = new ParticleEvent(transform.position, particleSystem);
            particle.FireEvent();
        }
        if(transform.tag == "Enemy")
        {

            attack = Instantiate(Aoe, transform.position, Quaternion.Euler(-90f,0f,0f));
        }
        else
        {
            attack = Instantiate(Aoe, transform);
        }
        //Destroy(attack, 0f);
    }
}
