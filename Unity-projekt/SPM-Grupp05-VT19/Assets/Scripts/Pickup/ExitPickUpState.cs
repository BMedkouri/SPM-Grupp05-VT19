using System.Collections;
using System.Collections.Generic;
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
        GetComponentInParent<Player>().Transition<OnGroundState>();
        GetComponent<ActiveWeapon>().SetActiveWeapon(excalibur);
    }
}
