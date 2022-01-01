using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Tile : MonoBehaviour
{
    public Vector2Int LocalCoords { get; set; } = new Vector2Int(-1, -1);
    public event Action<Tile, Vector2Int> OnClick;
    //public static UnityEvent<int> OnClick = new UnityEvent<int>();

    public void Init(int x, int y)
    {
        LocalCoords = new Vector2Int(x, y);
        transform.position = new Vector3(x, y);
        name = LocalCoords.ToString();
    }

    private void OnMouseDown()
    {
        //или через OnPointerDown или у Brackeys SystemEvent
        //Mouse over game object - еще где-то видел
        OnClick?.Invoke(this, LocalCoords);
        Debug.Log($"<color=cyan> клик на тайл {LocalCoords}  </color>");
    }
}