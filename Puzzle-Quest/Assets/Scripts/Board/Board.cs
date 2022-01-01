using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int _width = 8;
    [SerializeField] private int _height = 8;
    [SerializeField] private Dot _dotPrefab;
    //[SerializeField] private Dot[] _dotPrefabs;
    [SerializeField] private Dictionary<DotColor, Color> _dotTypes = new Dictionary<DotColor, Color>
    {
        {DotColor.Blue, Color.blue},
        {DotColor.Red, Color.red},
        {DotColor.Green, Color.green},
        {DotColor.Yellow, Color.yellow},
    };
    
    [SerializeField] private Vector2Int _lastSelectedCoords = _v2IntInvalid;
    private Dot _lastClicked;
    
    private static Vector2Int _v2IntInvalid = new Vector2Int(-1, -1);

    public Vector2Int Sizes => new Vector2Int(_width, _height);

    private Dot[,] _allDots;

    private void Start()
    {
        Camera.main.GetComponent<CameraManager>().SetupCamera(_width, _height);
        CreateBoard();
    }

    private Dot PlaceDot(int x, int y)
    {
        Dot newDot = Instantiate(_dotPrefab, transform);
        _allDots[x, y] = newDot;

        int randomIndex = UnityEngine.Random.Range(0, _dotTypes.Count);
        DotColor dotType = _dotTypes.ElementAt(randomIndex).Key;
        Color color = _dotTypes[dotType];

        newDot.Init(x, y, dotType);

        newDot.GetComponent<SpriteRenderer>().color = color;
        
        return newDot;
    }
    

    /*private Dot GetRandomDot()
    {
        //int index = UnityEngine.Random.Range(0, _dotPrefabs.Length);
        return _dotPrefabs[index];
    }*/


    private void FillRandomDots()
    {
        //for (int y = _height -1 ; y >= 0 ; y--) 
        for (int y = 0 ; y < _height ; y++) 
        for (int x = 0; x < _width; x++)
        {
            //Dot dot = GetRandomDot();

            //dot.OnClick += DotClickHandler;
            var newDot = PlaceDot(x, y);
        }
        
    }

    public void HandleClick(Vector2Int clickedLocalCoords)
    {
        Debug.Log($"<color=cyan> board HandleClick  </color>");
        //fixme если выделил клетку, но потом спеллом убил ее!
        bool wasSelected = _lastSelectedCoords != _v2IntInvalid;
        if (clickedLocalCoords == _v2IntInvalid)
        {
            Debug.Log($"<color=cyan> некорректно  </color>");
        }
        else if (wasSelected == false)
        {
            Select();
            void Select() => _lastSelectedCoords = clickedLocalCoords;
        }
        else if (clickedLocalCoords == _lastSelectedCoords)
        {
            Deselect();
        }
        else /*if (IsNeighboring(clickedLocalCoords, _lastSelectedCoords))*/
        {
            SwitchDots(clickedLocalCoords, _lastSelectedCoords);
        }
    }


    private void SwitchDots(Vector2Int one, Vector2Int two)
    {
        Dot dotOne = _allDots[one.x, one.y];
        var dotTwo = _allDots[two.x, two.y];
        _allDots[one.x, one.y] = dotTwo;
        _allDots[two.x, two.y] = dotOne;
        
        dotOne.Move(one);
        dotTwo.Move(two);
    }

    private bool IsNeighboring(Vector2Int one, Vector2Int two)
    {
        if (one.x == two.x)
        {
            
            return false ;
        }

        return true ;
    }

    private void Deselect()
    {
        //снять подсветку
        Debug.Log($"<color=cyan>  DeselectClicked() </color>");
        _lastSelectedCoords = _v2IntInvalid;
    }
    
    private bool IsWithinBounds(int x, int y) => (x >= 0 && x < _width && y >= 0 && y < _height);


    public Tile[,] CreateBoard()
    {
        Tile[,] tileArr = new Tile[_width, _height];
        var boardPosition = transform.position;

        float xPos = boardPosition.x;
        float yPos = boardPosition.y;
        //Vector2 tileSize = _tilePrefab.GetComponent<SpriteRenderer>().bounds.size;
        Sprite cashSprite = null;

        _allDots= new Dot[_width, _height];

        //начинает с лев нижнего угла наполнять и вверх?

        FillRandomDots();

        //newTile.transform.position = new Vector2(xPos + (tileSize.x * x), yPos + (tileSize.y * y)); =udeck
/*
            tileArr[x, y] = newTile;//=поместил в массив

            List<Sprite> tempSprite = new List<Sprite>();
            tempSprite.AddRange(sprites);

            tempSprite.Remove(cashSprite);
            if (x > 0)
            {
                tempSprite.Remove(tileArr[x - 1, y].GetComponent<SpriteRenderer>().sprite);//из списка удаляем изобр кот слева
            }
            newTile.GetComponent<SpriteRenderer>().sprite = tempSprite[Random.Range(0, tempSprite.Count)];//sprites.Length
            cashSprite = newTile.GetComponent<SpriteRenderer>().sprite;
*/
        

        return tileArr;
    }
}