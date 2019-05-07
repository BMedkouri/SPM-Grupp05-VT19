using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] attacks;
    private string attackName;
    private int index;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

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
