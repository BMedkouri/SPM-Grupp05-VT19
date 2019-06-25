/*
 * @author Anders Ragnar
 */

 /// <summary>
 /// this is the class that we cast to the temporary behaviour the enemy is in.
 /// </summary>
public class Behaviour : BehaviourState
{
    public BehaviourTree BehaviourTree { get; set; }
    
    public Behaviour(BehaviourTree behaviourTree)
    {
        BehaviourTree = behaviourTree;
    }
}
