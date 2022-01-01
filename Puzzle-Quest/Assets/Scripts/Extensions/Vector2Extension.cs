using System;
using UnityEngine;

namespace Extensions
{
    public static class Extension
    {
        public static Vector2Int Invalid => new Vector2Int(-1, -1);

        public static void Add(this Vector2 v0, Vector2 v1)
        {
            v0 = new Vector2(v0.x + v1.x, v0.y + v1.y);
        }
        
        public static DateTime Tomorrow => DateTime.Now.AddDays(1);
    }

    //class Vector2 { }
    
}