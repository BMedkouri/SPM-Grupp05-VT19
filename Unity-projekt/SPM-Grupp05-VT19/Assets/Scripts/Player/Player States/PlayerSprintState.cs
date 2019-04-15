using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerSprintState")]
public class PlayerSprintState : RunState
{
    // Attributes
    [SerializeField] private float staminaExpenditure;  // Stamina cost per second

    // Methods
    public override void Enter()
    {
        base.Enter();

        if (owner.GetCurrentStamina() < staminaExpenditure * Time.deltaTime)
        {
            owner.Transition<RunState>();
        }
    }

    public override void HandleUpdate()
    {
        Debug.Log(GetDirection());
        if (Input.GetKey(KeyCode.LeftShift) && GetDirection() != Vector3.zero)
        {
            Debug.Log(staminaExpenditure * Time.deltaTime);
            owner.LoseStamina(staminaExpenditure * Time.deltaTime);

            if (owner.GetCurrentStamina() < staminaExpenditure * Time.deltaTime)
            {
                owner.Transition<RunState>();
            }
        }
        else
        {
            owner.Transition<RunState>();
        }
        base.HandleUpdate();
    }
}
