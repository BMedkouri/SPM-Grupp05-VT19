//Author: Bilal El Medkouri

using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public bool HasInteractableObjectBeenActivated { get; set; }    // Chest in level one, key in level two
    public bool HasDoorBeenOpened { get; set; }                     // Gate in level one, hidden door in level two

    // TODO: Enemies

    private void Awake()
    {
        Instance = this;

        HasInteractableObjectBeenActivated = false;
        HasDoorBeenOpened = false;
    }
}
