using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceColliderType : MonoBehaviour
{
 public enum Mode {  Default, Grass, Bricks }
    public Mode terrainType;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public string GetTerrainType()
    {
        string typeString = "";
        
        switch(terrainType)
        {
            case Mode.Default:
                typeString = "Default";
                break;
            case Mode.Grass:
                typeString = "Grass";
                break;
            case Mode.Bricks:
                typeString = "Bricks";
                break;
            default:
                typeString = "";
                break;
        }
        return typeString;
    }
}
