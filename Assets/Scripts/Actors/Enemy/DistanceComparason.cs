using System.Collections;
using System;
using UnityEngine;

public class DistanceComparason : IComparer
{
    private Transform compareTransform;

    public DistanceComparason(Transform compTransform)
    {
        compareTransform = compTransform;
    }

    public int Compare(object x, object y)
    {
        Collider xCol = x as Collider;
        Collider yCol = y as Collider;

        Vector3 Offset = xCol.transform.position - compareTransform.position;
        float xDistance = Offset.sqrMagnitude;

        Offset = yCol.transform.position - compareTransform.position;
        float yDistance = Offset.sqrMagnitude;

        return xDistance.CompareTo(yDistance);
    }
}
