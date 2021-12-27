using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Tiles : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    
    private void Start()
    {
        FillTiles();
    }

    private void FillTiles()
    {
        for (int x = 0; x < 8; x++)
        for (int y = 0; y < 8; y++)
        {
            Tile newTile = Instantiate(_tilePrefab, transform);
            newTile.transform.position = new Vector3(x, y);
            //родителем отедльный объект и в скрипте на нем - обработка кликов и передача в Board.cs
        }
    }

}
