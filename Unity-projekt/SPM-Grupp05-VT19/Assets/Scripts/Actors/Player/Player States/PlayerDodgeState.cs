//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerDodgeState")]
public class PlayerDodgeState : PlayerOnGroundState
{
    // Attributes

    [Header("Dodge properties:")]
    [SerializeField] private float dodgeTimer; // TODO: Replace this with animation length
    [SerializeField] private float dodgeSpeed;

    [Header("Stamina cost:")]
    [SerializeField] private float staminaExpenditure;

    private float countDown;

    /// <summary>
    /// Adds Velocity in the direction of the Joystick to make it feel like a dodge.
    /// </summary>
    public override void Enter()
    {
        base.Enter();
        if (owner.CurrentStamina < staminaExpenditure)
        {
            owner.Transition<PlayerOnGroundState>();
        }
        else
        {
            owner.Physics.Velocity += (dodgeSpeed * owner.Physics.Direction == Vector3.zero ? Vector3.back : owner.Physics.Direction);
            //owner.Animator.applyRootMotion = true;
            owner.Animator.SetTrigger("Dodge");
        }
    }

    public override void HandleUpdate()
    {
    }

    //public override void Exit()
    //{
    //    base.Exit();
    //    owner.Animator.applyRootMotion = false;
    //}
}
