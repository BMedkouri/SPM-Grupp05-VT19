//Author: Bilal El Medkouri

using System.Collections.Generic;

public class LevelData
{
    public string LevelName { get; set; }
    public Dictionary<Enemy, int> Enemies { get; set; }
    public bool IsDoorOpen { get; set; }
    public bool IsInteractableObjectActive { get; set; }
}


// Reference for interactable object per level
/*
public class LevelOneData : LevelData
{
    public bool IsChestOpen { get; set; }
}

public class LevelTwoData : LevelData
{
    public bool IsKeyLooted { get; set; }

}
*/
