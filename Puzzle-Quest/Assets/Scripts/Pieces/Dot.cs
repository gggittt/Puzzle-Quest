using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    [SerializeField] private DotColor _dotType = DotColor.None;
    [SerializeField] private float _moveTime = .4f;
    public DotColor DotType => _dotType;

    public Vector2Int LocalCoords { get; set; } = new Vector2Int(-1, -1);
    
    //todo унаследовать Dot and Tile от одного родителя Piece = в нем поле LocalCoords.
    public void Init(int x, int y)
    {
        //_dotType = type;
        LocalCoords = new Vector2Int(x, y);
        transform.position = new Vector3(x, y); // или -y?
        
        name = ToString();
        //Debug.Log($"<color=cyan> {name} </color>");
        var a = Vector2Int.zero;
    }

    public override string ToString() => _dotType + " ball " + LocalCoords;


    /*
    public event Action<Vector2Int> OnClick;
     
    private void OnMouseDown()
    {
        //или через OnPointerDown или у Brackeys SystemEvent
        //Mouse over game object - еще где-то видел
        OnClick?.Invoke(LocalCoords);
        
    }*/

    public void Move(Vector2Int targetInLocalCoord)
    {
        LocalCoords = targetInLocalCoord;
        var worldCord = Global.ToWorldCoordinate(targetInLocalCoord);
        
        GetComponent<DotMove>().Move(worldCord, _moveTime);
    }
}