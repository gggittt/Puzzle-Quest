using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tiles : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Board _board;
    private Tile[,] _allTiles;

    private void Start()
    {
        FillTiles();
    }

    private void FillTiles()
    {
        _allTiles = new Tile[_board.Sizes.x, _board.Sizes.y];


        //for (int y = _board.Sizes.y -1 ; y >= 0 ; y--)
        for (int y = 0 ; y < _board.Sizes.y ; y++) 
        for (int x = 0; x < _board.Sizes.x; x++)
        {
            Tile newTile = Instantiate(_tilePrefab, transform);
            
            newTile.Init(x, y);
            newTile.OnClick += HandlerClickOnTile;//fixme отписаться где-то?

            _allTiles[x, y] = newTile;
        }
    }

    private void HighlightTiles(IEnumerable<Tile> tiles)
    {
        foreach (Tile tile in tiles)
        {
            tile.GetComponent<TileColor>().Illuminate();
        }
    }
    
    private void HandlerClickOnTile(Tile sender, Vector2Int coords)
    {
        _board.HandleClick(coords);
        //и отсюда пересылаю в Board
        //убрать один из аргументов
        sender.GetComponent<TileColor>().SwitchIlluminate();
    }
}


