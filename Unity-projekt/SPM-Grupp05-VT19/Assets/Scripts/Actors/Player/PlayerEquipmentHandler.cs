//Author: Bilal El Medkouri

using UnityEngine;

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
    private void Awake()
    {
        UpdateWeapon();
        UpdateOffhand();
    }

    #region Weapon
    private void UpdateWeapon()
    {
        Weapon = EquippedWeapon.GetComponent<Weapon>();
        equippedWeaponID = Weapon.ItemID;
    }

    private void UpdateWeapon(int weaponID)
    {
        foreach (Weapon weapon in EquipableItems.WeaponList)
        {
            weapon.gameObject.SetActive(false);

            if (weapon.ItemID.Equals(EquippedWeaponID))
            {
                EquippedWeapon = weapon.gameObject;
                EquippedWeapon.SetActive(true);

                Weapon = weapon;
            }
        }
    }
    #endregion Weapon

    #region Offhand
    private void UpdateOffhand()
    {
        Offhand = EquippedOffhand.GetComponent<Offhand>();
        equippedOffhandID = Offhand.ItemID;
    }

    private void UpdateOffhand(int offhandID)
    {
        foreach (Offhand offhand in EquipableItems.OffhandList)
        {
            offhand.gameObject.SetActive(false);

            if (offhand.ItemID.Equals(EquippedOffhandID))
            {
                EquippedOffhand = offhand.gameObject;
                EquippedOffhand.SetActive(true);

                Offhand = offhand;
            }
        }
    }
    #endregion Offhand

    #endregion Methods
}
