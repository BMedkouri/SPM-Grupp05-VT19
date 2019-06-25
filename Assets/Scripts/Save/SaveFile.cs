using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFile
{
    /*
     * enemy position och rotation
     * player position och rotation
     * pickup och objekt av pickup
     * liv och hälsa
     */
    public SaveFile(List<BehaviourTree> currentEnemies, List<BehaviourTree> removedEnemies, Player currentPlayer)
    {
        Debug.Log(currentPlayer.transform.position);
        Enemies = currentEnemies;
        RemovedEnemies = removedEnemies;
        Player = currentPlayer;
        PlayerTransform = currentPlayer.transform;
        X = currentPlayer.transform.position.x;
        Y = currentPlayer.transform.position.y;
        Z = currentPlayer.transform.position.z;
        RotationX = currentPlayer.transform.rotation.x;
        RotationY = currentPlayer.transform.rotation.y;
        RotationZ = currentPlayer.transform.rotation.z;
        RotationW = currentPlayer.transform.rotation.w;
    }
    public List<BehaviourTree> RemovedEnemies { get; set; }
    public List<BehaviourTree> Enemies { get; set; }
    public Player Player { get; set; }
    public Vector3 PlayerPosition { get; set; }
    public Transform PlayerTransform { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float RotationX { get; set; }
    public float RotationY { get; set; }
    public float RotationZ { get; set; }
    public float RotationW { get; set; }
    
}
