using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    // Active weapon
    [SerializeField] private GameObject activeWeapon; 

    public GameObject GetActiveWeapon()
    {
        return activeWeapon;
    }

    public void SetActiveWeapon(GameObject weapon)
    {
        activeWeapon = weapon;
    }

    public string GetActiveWeaponName()
    {
        return activeWeapon.GetComponent<Weapon>().GetWeaponName();
    }

    public float GetActiveWeaponDamage()
    {
        return activeWeapon.GetComponent<Weapon>().GetWeaponDamage();
    }
}
