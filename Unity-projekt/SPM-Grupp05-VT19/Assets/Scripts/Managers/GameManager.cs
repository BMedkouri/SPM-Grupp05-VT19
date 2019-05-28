//Author: Bilal El Medkouri

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #region SaveGame
    public void SaveGame(Vector3 savePosition)
    {
        SavePlayer(savePosition);
        SaveLevel(SceneManager.GetActiveScene().buildIndex);

    }

    private void SavePlayer(Vector3 savePosition)
    {
        Player player = Player.PlayerReference;

        // Player position
        PlayerPrefs.SetFloat("x", savePosition.x);
        PlayerPrefs.SetFloat("y", savePosition.y);
        PlayerPrefs.SetFloat("z", savePosition.z);

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

        // TODO: Save enemies 
        // Check out this link: https://www.youtube.com/watch?v=J6FfcJpbPXE

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

    #region LoadGame
    public void LoadGame()
    {
        // TODO
    }
    #endregion LoadGame
}
