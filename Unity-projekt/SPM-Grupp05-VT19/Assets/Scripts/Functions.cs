using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Functions
{
    public static Vector3 CalculateNormalForce(Vector3 velocity, Vector3 normal)
    {
        if (Vector3.Dot(velocity, normal) > 1)
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
}
