using System;
using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    public static event Action<bool> OnCursorLeave;

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        if (mousePosition.x < Screen.width / 2) /* Mouse is on the left side */ 
        {
            OnCursorLeave?.Invoke(false);
        }
        else
        {
            OnCursorLeave?.Invoke(true);
        }
    }
}
