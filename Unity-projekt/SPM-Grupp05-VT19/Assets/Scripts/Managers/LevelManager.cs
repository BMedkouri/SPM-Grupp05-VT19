//Author: Bilal El Medkouri

using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    /// <summary>
    /// List of enemies, per scene.
    /// The key is each enemy's ID, and the value is whether or not they are alive. 0 == Dead, 1 == Alive.
    /// </summary>
    public Dictionary<int, int> EnemyDictionary { get; set; }

    // Doors and interactables
    public bool HasInteractableObjectBeenActivated { get; set; }    // Chest in level one, key in level two
    public bool HasDoorBeenOpened { get; set; }                     // Gate in level one, hidden door in level two

    private void Awake()
    {
        Debug.Log("LM Awake");
        Instance = this;

        EnemyDictionary = new Dictionary<int, int>();

        HasInteractableObjectBeenActivated = false;
        HasDoorBeenOpened = false;
    }

    public void SaveEnemies()
    {
        foreach (int enemyID in EnemyDictionary.Keys)
        {
            PlayerPrefs.SetInt("enemy" + enemyID, EnemyDictionary[enemyID]);
        }
    }
}
