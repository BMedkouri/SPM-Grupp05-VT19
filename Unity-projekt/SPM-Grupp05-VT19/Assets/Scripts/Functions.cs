//Author: Bilal El Medkouri

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for holding our functions.
/// </summary>
public static class Functions
{
    public static Vector3 CalculateNormalForce(Vector3 velocity, Vector3 normal)
    {
        if (Vector3.Dot(velocity, normal) >= 1)
        {
            return Vector3.zero;
        }
        else
        {
            Vector3 projection = Vector3.Dot(velocity, normal) * normal;
            return -projection;
        }
    }

    public static float CalculateFriction(float frictionCoefficient, Vector3 normalForce)
    {
        return frictionCoefficient * normalForce.magnitude;
    }

    public static float CalculateAngleOfImpact(Vector3 vector1, Vector3 vector2)
    {
        return Vector3.Angle(vector1, vector2) - 90;
    }

    public static float CalculateHypotenuse(float angle, float shortSideLength)
    {
        return shortSideLength / Mathf.Sin(angle);
    }
}
