//Author: Bilal El Medkouri

using UnityEngine;

public static class GamePersistence
{
    public static void SaveData(Player player)
    {
        PlayerPrefs.SetFloat("x", player.transform.position.x);
        PlayerPrefs.SetFloat("y", player.transform.position.y);
        PlayerPrefs.SetFloat("z", player.transform.position.z);
        PlayerPrefs.SetFloat("health", player.HealthComponent.CurrentHealth);
        PlayerPrefs.SetFloat("stamina", player.CurrentStamina);
        PlayerPrefs.SetFloat("energy", player.CurrentEnergy);
        PlayerPrefs.SetInt("weaponID", player.PlayerEquipmentHandler.EquippedWeaponID);
        PlayerPrefs.SetInt("offhandID", player.PlayerEquipmentHandler.EquippedOffhandID);
    }

    public static PlayerData LoadPlayerData()
    {
        float x = PlayerPrefs.GetFloat("x");
        float y = PlayerPrefs.GetFloat("y");
        float z = PlayerPrefs.GetFloat("z");
        float health = PlayerPrefs.GetFloat("health");
        float stamina = PlayerPrefs.GetFloat("stamina");
        float energy = PlayerPrefs.GetFloat("energy");
        int weaponID = PlayerPrefs.GetInt("weaponID");
        int offhandID = PlayerPrefs.GetInt("offhandID");

        PlayerData playerData = new PlayerData()
        {
            Location = new Vector3(x, y, z),
            Health = health,
            Stamina = stamina,
            Energy = energy,
            WeaponID = weaponID,
            OffhandID = offhandID
        };

        return playerData;
    }
}
