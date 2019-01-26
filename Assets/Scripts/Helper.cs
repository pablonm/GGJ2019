using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static Vector2 NormalizeVector(float x, float y)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        return new Vector2(x / distance, y / distance);
    }

    public static Vector2 NormalizeVector(Vector2 v1, float d)
    {
        return new Vector2(v1.x / d, v1.y / d);
    }

    public static float Distance(Vector2 v1, Vector2 v2)
    {
        return Mathf.Sqrt(Mathf.Pow(v1.x - v2.x, 2) + Mathf.Pow(v1.y - v2.y, 2));
    }

    public static Vector2 OrthogonalVector(Vector2 v)
    {
        return NormalizeVector(-v.y / v.x, 1);
    }
}
