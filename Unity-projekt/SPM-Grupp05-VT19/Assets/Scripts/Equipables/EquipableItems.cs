//Author: Bilal El Medkouri

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Superclass for equipable items.
/// </summary>
public class EquipableItems : MonoBehaviour
{
    #region Variables
    [Header("Item properties")]
    [SerializeField] private int itemID;
    [SerializeField] private string itemName;
    [SerializeField] private float itemDamage;

    public int ItemID { get => itemID; }
    public string ItemName { get => itemName; }
    public float ItemDamage { get => itemDamage; }

    public Rigidbody Rigidbody { get; private set; }
    public static List<Weapon> WeaponList { get; private set; }
    public static List<Offhand> OffhandList { get; private set; }

    private static bool hasRunOnce;
    #endregion Variables

    #region Methods
    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();

        // Makes sure that the lists are only created once. 
        // The subclasses all call upon Base.Awake() to set their Rigidbody,
        // but we don't want the lists to be created once per item, since the lists are static.
        if (hasRunOnce == true)
            return;
        hasRunOnce = true;

        WeaponList = new List<Weapon>();
        OffhandList = new List<Offhand>();
    }

    protected virtual void OnCollisionEnter(Collision collision) { }
    #endregion Methods
}
