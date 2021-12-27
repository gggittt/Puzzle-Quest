using UnityEngine;


public class Tile : MonoBehaviour
{
    public Vector2Int Coords { get; set; } = new Vector2Int(-1, -1);

    public void Init(int x, int y)
    {
        Coords = new Vector2Int(x, y);
    }
}