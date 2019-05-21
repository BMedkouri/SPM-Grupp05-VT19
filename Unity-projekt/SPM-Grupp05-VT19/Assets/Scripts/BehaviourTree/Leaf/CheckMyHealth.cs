using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMyHealth : Leaf
{
    private float health;
    public CheckMyHealth(float health)
    {
        this.health = health;
    }
    public override NodeStatus OnBehave(BehaviourState state)
    {
        behaviour = (Behaviour)state;
        enemy = behaviour.BehaviourTree;

        HealthComponent healthStatus = enemy.GetComponent<HealthComponent>();
        if(health > healthStatus.CurrentHealth)
        {
            return NodeStatus.SUCCESS;
        }
        else
        {
            return NodeStatus.FAILURE;
        }
    }

    public override void OnReset()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
