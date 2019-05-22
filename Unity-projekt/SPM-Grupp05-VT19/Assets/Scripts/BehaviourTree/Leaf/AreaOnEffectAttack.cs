using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOnEffectAttack : Leaf
{
    private float timer, countDown;
    public AreaOnEffectAttack(float attackTimer)
    {
        timer = attackTimer;
    }
    
    public override NodeStatus OnBehave(BehaviourState state)
    {
        if(countDown < 0)
        {
            //sätt igång skadan här
            return NodeStatus.SUCCESS;
        }
        //uppladdning ska köras här
        return NodeStatus.RUNNING;
    }

    public override void OnReset()
    {
        countDown = timer;
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
