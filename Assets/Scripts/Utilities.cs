using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{

    public static List<Vector2Int> Directions8 = new List<Vector2Int>() {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right,
        Vector2Int.up + Vector2Int.left,
        Vector2Int.up + Vector2Int.right,
        Vector2Int.down + Vector2Int.left,
        Vector2Int.down + Vector2Int.right
    };

    public static Vector3 GetMousePositsion()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
