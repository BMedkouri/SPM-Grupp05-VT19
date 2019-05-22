﻿//Author: Bilal El Medkouri

using System.Collections.Generic;
using UnityEngine;

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
    #endregion Variables

    #region Methods
    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        WeaponList = new List<Weapon>();
        OffhandList = new List<Offhand>();
    }

    protected virtual void OnCollisionEnter(Collision collision) { }
    #endregion Methods
}
