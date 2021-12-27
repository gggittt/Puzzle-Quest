using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    [SerializeField] private DotColor _dotType  = DotColor.None;
    public DotColor DotType => _dotType;
    
    public Vector2Int Coords { get; set; } = new Vector2Int(-1, -1);

    public void Init(int x, int y, DotColor type)
    {
        _dotType = type;
        Coords = new Vector2Int(x, y);
        transform.position = new Vector3(x, y); // или -y?
        
        name = x + ", " + y;
        Debug.Log($"<color=cyan> {name}, {type} </color>");

    }
    
}


