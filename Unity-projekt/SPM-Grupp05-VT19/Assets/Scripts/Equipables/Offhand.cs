//Author: Bilal El Medkouri

using UnityEngine;

public class Offhand : EquipableItems
{
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
}
