using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAoe : MonoBehaviour
{
    [SerializeField] private GameObject Aoe;
    public void instantiateAoe()
    {
        GameObject attack = Instantiate(Aoe);
    }
}
