/*
 * @author Anders Ragnar
 */

 /// <summary>
 /// The contact with the Enemy
 /// </summary>
public class Behaviour : BehaviourState
{
    public BehaviourTree BehaviourTree { get; set; }
    
    public Behaviour(BehaviourTree behaviourTree)
    {
        BehaviourTree = behaviourTree;
    }
}
