using Godot;
using System;


public class VectorRotations
{
    public static float AngleBetweenVectors(Vector2 a, Vector2 b)
    {
        float cross = a.X * b.Y - a.Y * b.X;
        float dot = a.Dot(b);

        return Mathf.RadToDeg(Mathf.Atan2(cross, dot));
    }

    public static Vector2 RotateVector(Vector2 v, float radians)
    {
        float cs = Mathf.Cos(radians);
        float sn = Mathf.Sin(radians);
        return new Vector2(v.X * cs - v.Y * sn, v.X * sn + v.Y * cs);
    }
}
