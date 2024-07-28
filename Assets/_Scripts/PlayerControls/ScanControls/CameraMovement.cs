using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float movementScale;
    [SerializeField] private Vector2 areaLimits;

    private void OnAwake()
    {
        PlayerInput.OnMove += HandleMove;
    }

    private void OnDestroy()
    {
        PlayerInput.OnMove -= HandleMove;
    }

    private void HandleMove(Vector2 movement)
    {
        transform.Translate(movement * movementScale, Space.Self);

        //Clamp
        Vector3 position = transform.localPosition;
        position.x = Mathf.Clamp(position.x, -areaLimits.x, areaLimits.x);
        position.y = Mathf.Clamp(position.y, -areaLimits.y, areaLimits.y);
        transform.localPosition = position;
    }
}
