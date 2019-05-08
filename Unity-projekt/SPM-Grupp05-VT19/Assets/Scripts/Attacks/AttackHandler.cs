//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds an array of an actors attacks in it.
/// It then shoots off events based on their indexes, when called upon from an animation event.
/// This class mostly holds objects and makes sure that the correct attack is fired, the actual logic for collision etc. is in AttackController.
/// </summary>
public class AttackHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] attacks;
    private string attackName;
    private int index;

    /// <summary>
    /// This method compares attackName to the items in the array, to find the corresponding index.
    /// </summary>
    private void FindIndex()
    {
        for (int i = 0; i < attacks.Length; i++)
        {
            if(attacks[i].name.Equals(attackName))
            {
                index = i;
            }
        }
    }
    
    private void TriggerParticleEvent()
    {
        attacks[index].GetComponent<AttackController>().TriggerParticleEvent();
    }

    private void TriggerSoundEvent()
    {
        attacks[index].GetComponent<AttackController>().TriggerSoundEvent();
    }

    private void CheckForCollision()
    {
        if(attacks[index].GetComponent<AttackController>().GetType() == typeof(BoxAttackController))
        {
            attacks[index].GetComponent<BoxAttackController>().CheckForCollision();
        }
        else if(attacks[index].GetComponent<AttackController>().GetType() == typeof(SphereAttackController))
        {
            attacks[index].GetComponent<SphereAttackController>().CheckForCollision();
        }
        else
        {
            //New debug event.
        }
    }

    public void SetAttackName(string attackName)
    {
        this.attackName = attackName;
        FindIndex();
    }
}
