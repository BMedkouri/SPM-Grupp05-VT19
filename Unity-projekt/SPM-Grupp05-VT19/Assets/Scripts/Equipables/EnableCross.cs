using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCross : MonoBehaviour
{
    public BoxCollider box;
    public void EnableCrossCollider()
    {
        box.enabled = true;
        Debug.Log("On");
        //transform.Find("Cross").GetComponent<BoxCollider>().enabled = true;

    }
    public void DisableCrossCollider()
    {
        //transform.Find("Cross").GetComponent<BoxCollider>().enabled = false;
        box.enabled = false;
        Debug.Log("Off");
    }
}
