using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int _width = 8;
    [SerializeField] private int _height = 8;
    [SerializeField] private Dot[] _dotPrefabs;
    
    private Tile[,] _allTiles;
    private Dot[,] _allDots;

    private void Start()
    {
        Camera.main.GetComponent<CameraManager>().SetupCamera(_width, _height);
        CreateBoard();
    }

    public Tile[,] CreateBoard()
    {
        Tile[,] tileArr = new Tile[_width, _height];
        var boardPosition = transform.position;

        float xPos = boardPosition.x;
        float yPos = boardPosition.y;
        //Vector2 tileSize = _tilePrefab.GetComponent<SpriteRenderer>().bounds.size;
        Sprite cashSprite = null;

        _allTiles = new Tile[_width, _height];
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

    private void PlaceDot(int x, int y, Dot dot)
    {
        Dot newDot = Instantiate(dot, transform);
        _allDots[x, y] = newDot;

        newDot.Init(x, y, DotColor.None);
    }

    private Dot GetRandomDot()
    {
        int index = UnityEngine.Random.Range(0, _dotPrefabs.Length);
        return _dotPrefabs[index];
    }

    
    private void FillRandomDots()
    {
        for (int x = 0; x < _width; x++)
        for (int y = 0; y < _height; y++)
        {
            var dot = GetRandomDot();
            PlaceDot(x, y, dot);
        }
    }

    
    
}