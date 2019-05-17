//Author: Bilal El Medkouri

using UnityEngine;

public class ExitPickUpState : MonoBehaviour
{
    [SerializeField] private GameObject excalibur;

    private void Bankai()
    {
        excalibur.SetActive(true);
    }

    private void ChangePlayerState()
    {
        Player.PlayerReference.Transition<PlayerOnGroundState>();
        Player.PlayerReference.ActiveWeaponGameObject = excalibur;
    }
}
