using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        if (mousePosition.x < Screen.width / 2) /* Mouse is on the left side */ 
        {
            PlayerInput.instance.RaycastState(false);
        }
        else
        {
            PlayerInput.instance.RaycastState(true);
        }
    }
}
