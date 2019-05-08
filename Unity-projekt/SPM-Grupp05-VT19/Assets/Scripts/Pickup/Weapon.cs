using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private string weaponName;
    [SerializeField] private float weaponDamage;
    // Add possible trail effect and particle effect (in form of a glow(?))

    public string GetWeaponName()
    {
        return weaponName;
    }

    public float GetWeaponDamage()
    {
        return weaponDamage;
    }
}
