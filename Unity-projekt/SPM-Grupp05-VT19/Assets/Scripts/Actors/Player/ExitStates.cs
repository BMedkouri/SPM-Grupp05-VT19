//Author: Bilal El Medkouri

using UnityEngine;

/// <summary>
/// Called on from the player's animator to exit the current state.
/// </summary>
public class ExitStates : MonoBehaviour
{
    private void ExitCurrentState()
    {
        Player.Instance.Transition<PlayerOnGroundState>();
    }
}
