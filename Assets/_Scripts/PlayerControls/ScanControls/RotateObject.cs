using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerInput.OnRotate += HandleMove;
    }

    private void OnDisable()
    {
        PlayerInput.OnRotate -= HandleMove;
    }

    private void HandleMove(float theta)
    {
        transform.Rotate(Vector3.up,theta);
    }
}
