using UnityEngine;

public static class Global
{
    public static Vector2 ToWorldCoordinate(Vector2Int local)
    {
        return new Vector2 (local.x, local.y);
    }

    public static Vector2Int ToLocalCoordinate(Vector2 world)
    {
        return Vector2Int.down;
        //расписать сдвиг, но в этом проекте камера сама центрируется
    }
}