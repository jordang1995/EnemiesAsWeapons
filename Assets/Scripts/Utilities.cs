using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public static Vector3 GetMousePositsion()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
