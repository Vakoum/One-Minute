using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MousePosition
{
    public static Vector2 MouseWorldPosition(Camera mainCamera)
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
