using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAoe : MonoBehaviour
{
    [SerializeField] private GameObject Aoe;
    public void InstantiateAOE()
    {
        GameObject attack = Instantiate(Aoe, transform);
        //Destroy(attack, 0.1f);
    }
}
