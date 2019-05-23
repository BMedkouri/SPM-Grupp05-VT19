﻿/*
 * @author Anders Ragnar
 */

 /// <summary>
 /// i haven't writen this class
 /// </summary>
public class Sequence : Composite
{
    int currentChild = 0;

    public Sequence(string compositeName, params Node[] nodes) : base(compositeName, nodes)
    {

    }

    public override NodeStatus OnBehave(BehaviourState state)
    {
        DebugEvent debug = new DebugEvent(children[currentChild] + " " + children[currentChild].Behave(state));
        //debug.FireEvent();
        NodeStatus ret = children[currentChild].Behave(state);
       switch (ret)
        {
            case NodeStatus.SUCCESS:
                currentChild++;
                break;

            case NodeStatus.FAILURE:
                return NodeStatus.FAILURE;
        }

        if (currentChild >= children.Count)
        {
            return NodeStatus.SUCCESS;
        } else if(ret == NodeStatus.SUCCESS)
        {
            
            // if we succeeded, don't wait for the next tick to process the next child
            return OnBehave(state);
        }

        return NodeStatus.RUNNING;
    }

    public override void OnReset()
    {
        currentChild = 0;
        foreach(Node child in children)
        {
            child.Reset();
        }
    }
}
