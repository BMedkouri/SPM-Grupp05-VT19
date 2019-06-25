//Author: Bilal El Medkouri

using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static Dictionary<int, BehaviourTree> Enemies { get; set; } = new Dictionary<int, BehaviourTree>();
    public static List<BehaviourTree> DeadEnemies { get; set; } = new List<BehaviourTree>();

    private Player player;

    private void Awake()
    {
        Instance = this;
        Debug.Log("Awake");
        player = Player.PlayerReference;
        //Player.PlayerReference.enabled = true;
        //Debug.Log(Player.PlayerReference.enabled);
        //Player.PlayerReference.Transition<PlayerOnGroundState>();
    }

    #region SaveGame
    public void SaveGame()
    {
        Debug.Log("save");
        List<BehaviourTree> saveEnemies = new List<BehaviourTree>();
        foreach(BehaviourTree bt in saveEnemies)
        {
            saveEnemies.Add(bt);
        }
        Debug.Log(Player.PlayerReference.transform.position);
        SaveFile save = new SaveFile(saveEnemies, DeadEnemies, Player.PlayerReference);

        string json = JsonUtility.ToJson(save);

        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
        //int currentScene = SceneManager.GetActiveScene().buildIndex;

        //SavePlayer(savePosition, currentScene);
        //SaveLevel(currentScene);
    }

    private void SavePlayer(Vector3 savePosition, int currentScene)
    {
        Player player = Player.PlayerReference;

        // Player position per level
        PlayerPrefs.SetFloat("playerXLevel" + currentScene, savePosition.x);
        PlayerPrefs.SetFloat("playerYLevel" + currentScene, savePosition.y);
        PlayerPrefs.SetFloat("playerZLevel" + currentScene, savePosition.z);

        // Health, stamina, and energy
        PlayerPrefs.SetFloat("currentHealth", player.HealthComponent.CurrentHealth);
        PlayerPrefs.SetFloat("currentStamina", player.CurrentStamina);
        PlayerPrefs.SetFloat("currentEnergy", player.CurrentEnergy);

        // Equipment
        PlayerPrefs.SetInt("weaponID", player.PlayerEquipmentHandler.EquippedWeaponID);
        PlayerPrefs.SetInt("offhandID", player.PlayerEquipmentHandler.EquippedOffhandID);

        // Holy nova
        int isHolyNovaUnlocked = player.IsHolyNovaUnlocked ? 1 : 0;
        PlayerPrefs.SetInt("isHolyNovaUnlocked", isHolyNovaUnlocked);

        // Level two key
        int hasLevelTwoKey = player.HasLevelTwoKey ? 1 : 0;
        PlayerPrefs.SetInt("hasLevelTwoKey", hasLevelTwoKey);
    }

    private void SaveLevel(int currentScene)
    {
        LevelManager level = LevelManager.Instance;

        // Scene
        PlayerPrefs.SetInt("currentScene", currentScene);

        // Enemies in current scene
        level.SaveEnemies();

        // Interactables and doors in current scene
        int hasInteractableObjectBeenActivated = level.HasInteractableObjectBeenActivated ? 1 : 0;
        int hasDoorBeenOpened = level.HasDoorBeenOpened ? 1 : 0;

        if (currentScene == 1)
        {
            // Pickup
            PlayerPrefs.SetInt("levelOneChest", hasInteractableObjectBeenActivated);

            // Gate
            PlayerPrefs.SetInt("levelOneDoor", hasDoorBeenOpened);
        }
        else if (currentScene == 2)
        {
            // Key
            PlayerPrefs.SetInt("levelTwoKey", hasInteractableObjectBeenActivated);

            // Hidden door
            PlayerPrefs.SetInt("levelTwoHiddenDoor", hasDoorBeenOpened);
        }
    }
    #endregion SaveGame

    public void NewGame()
    {
        ResetPlayerPrefs();
        LoadGame();
    }

    public void LoadGame()
    {
        Debug.Log("Load");
        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");

        SaveFile load = JsonUtility.FromJson<SaveFile>(json);
        Debug.Log(load + " json");
        List<BehaviourTree> loadEnemies = load.Enemies;
        DeadEnemies = load.RemovedEnemies;
        
        if(DeadEnemies != null)
        {
            Debug.Log("Dead enemies != null");
            foreach (BehaviourTree dead in DeadEnemies)
            {
                if (Enemies.ContainsKey(dead.Id) == true)
                {
                    Enemies[dead.Id].gameObject.SetActive(false);
                }
            }
        }
        Debug.Log(loadEnemies);
        if (loadEnemies != null)
        {
            Debug.Log("load enemies != null");
            foreach (BehaviourTree loadedEnemy in loadEnemies)
            {
                if (Enemies.ContainsKey(loadedEnemy.Id) == true)
                {
                    Enemies[loadedEnemy.Id].Agent.Warp(loadedEnemy.transform.position);
                    Enemies[loadedEnemy.Id].transform.rotation = loadedEnemy.transform.rotation;
                }
            }

        }        
        //Player.PlayerReference.GetComponent<Animator>().applyRootMotion = false;
        Player.PlayerReference.GetComponent<CharacterController>().Move(new Vector3(load.X, load.Y, load.Z));
        //Player.PlayerReference.GetComponent<CharacterController>().
        //Player.PlayerReference.transform.position = new Vector3(load.X, load.Y, load.Z);
        //Player.PlayerReference.transform.rotation = new Quaternion(load.RotationX, load.RotationY, load.RotationZ, load.RotationW);
        //Player.PlayerReference.GetComponent<Animator>().applyRootMotion = true;
        Debug.Log(new Vector3(load.X, load.Y, load.Z) + " Vector3");
        Debug.Log(Player.PlayerReference.transform.position);
    }


    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
