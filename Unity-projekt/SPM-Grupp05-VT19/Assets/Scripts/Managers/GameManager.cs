//Author: Bilal El Medkouri

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        Debug.Log("Awake");
        Player.PlayerReference.enabled = true;
        Debug.Log(Player.PlayerReference.enabled);
        Player.PlayerReference.Transition<PlayerOnGroundState>();
    }

    #region SaveGame
    public void SaveGame(Vector3 savePosition)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SavePlayer(savePosition, currentScene);
        SaveLevel(currentScene);
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
        // TODO: Create a loading scene with a loading bar
        LoadScene(PlayerPrefs.GetInt("currentScene", 1));
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
