//Author: Bilal El Medkouri

using UnityEngine;

/// <summary>
/// Class that handles the player's equipment.
/// 
/// The game objects are only used for debugging at the moment, the things that are used are the Weapon and Offhand classes, as well as the ID's.
/// 
/// When the ID changes, the active model is changed, as well as the script.
/// </summary>
public class PlayerEquipmentHandler : MonoBehaviour
{
    #region Variables

    #region Weapon
    [Header("Weapon")]
    [SerializeField] private GameObject equippedWeapon;
    public GameObject EquippedWeapon { get => equippedWeapon; private set { equippedWeapon = value; } }

    [SerializeField] private int equippedWeaponID;
    public int EquippedWeaponID
    {
        get => equippedWeaponID;
        set
        {
            equippedWeaponID = value;
            UpdateWeapon(value);
        }
    }

    public Weapon Weapon { get; private set; }
    #endregion Weapon

    #region Offhand
    [Header("Offhand")]
    [SerializeField] private GameObject equippedOffhand;
    public GameObject EquippedOffhand { get => equippedOffhand; private set { equippedOffhand = value; } }

    [SerializeField] private int equippedOffhandID;
    public int EquippedOffhandID
    {
        get => equippedOffhandID;
        set
        {
            equippedOffhandID = value;
            UpdateOffhand(value);
        }
    }

    public Offhand Offhand { get; private set; }
    #endregion Offhand

    #endregion Variables

    #region Methods

    #region Weapon
    private void UpdateWeapon(int weaponID)
    {
        /*
        foreach (Weapon weapon in EquipableItems.WeaponList)
        {
            weapon.gameObject.SetActive(false);

            if (weapon.ItemID.Equals(weaponID))
            {
                EquippedWeapon = weapon.gameObject;
                EquippedWeapon.SetActive(true);

                Weapon = weapon;
            }
        }
        */
    }
    #endregion Weapon

    #region Offhand
    private void UpdateOffhand(int offhandID)
    {
        /*
        foreach (Offhand offhand in EquipableItems.OffhandList)
        {
            offhand.gameObject.SetActive(false);

            if (offhand.ItemID.Equals(offhandID))
            {
                EquippedOffhand = offhand.gameObject;
                EquippedOffhand.SetActive(true);

                Offhand = offhand;
            }
        }
        */
    }
    #endregion Offhand

    #endregion Methods
}

