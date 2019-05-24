//Author: Bilal El Medkouri

using UnityEngine;

public class EnemyData
{
    public Vector3 Location { get; set; }
    public float Health { get; set; }
    public int ID { get; set; }
    public int IsAlive { get; set; } // 0 is dead, 1 is alive
    // TODO: CurrentState(?)
}
