//Author: Bilal El Medkouri

using UnityEngine;

public class Offhand : MonoBehaviour
{
    // Attributes
    [Header("Item properties")]
    [SerializeField] private string itemName;
    [SerializeField] private float itemDamage;
    [SerializeField] private float itemHealAmount;

    public string ItemName { get => itemName; }
    public float ItemDamage { get => itemDamage; }
    public float ItemHealAmount { get => itemHealAmount; }


    public Rigidbody Rigidbody { get; private set; }

    // Methods
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Weapon"))
        {
            // TODO: Add parry event
            Debug.Log("Parry");
        }

        // Check for collision with enemy?
    }
}
