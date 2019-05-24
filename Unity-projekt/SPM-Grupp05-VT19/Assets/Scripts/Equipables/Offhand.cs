//Author: Bilal El Medkouri

using UnityEngine;

/// <summary>
/// Subclass that handles Offhand items. Currently only one exists, but I've made this in case we want to implement more.
/// The offhand item is used for parrying, and for healing.
/// </summary>
public class Offhand : EquipableItems
{
    [SerializeField] private GameObject holyNova;
    // TODO: Connect this to the player's heal.
    [SerializeField] private float itemHealAmount;
    public float ItemHealAmount { get => itemHealAmount; }

    protected override void Awake()
    {
        base.Awake();
        OffhandList.Add(this);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Weapon"))
        {
            // TODO: Add parry event
            Debug.Log("Parry");
        }

        // Check for collision with enemy?
    }

    public void InstantiateHolyNova()
    {
        GameObject hn = Instantiate(holyNova, transform.position, Quaternion.identity);
    }
}
