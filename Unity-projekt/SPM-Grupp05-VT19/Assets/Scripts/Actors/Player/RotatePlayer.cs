using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public void Rotate(Vector3 direction)
    {
        //Inte riktigt säker på ifall jag behöver den bortkommenterade raden.
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), 0.2f);
        //transform.forward = direction;
    }
}
