using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Visability
{
    public static bool IsTargetVisible(Vector2 pos)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        var point = pos;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0.5f)
                return false;
        }
        return true;
    }
}
