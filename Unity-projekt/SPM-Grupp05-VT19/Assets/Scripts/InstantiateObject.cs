using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{

    [SerializeField] private GameObject insObject;

    public void InstansiateObject()
    {
        GameObject go = Instantiate(insObject, transform.position, Quaternion.Euler(-90f,0f, 0f));
        Destroy(go, 2f);
    }
}
