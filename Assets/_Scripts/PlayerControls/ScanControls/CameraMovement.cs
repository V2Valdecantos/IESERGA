using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector2 areaLimits;

    private void OnEnable()
    {
        PlayerInput.OnMove += HandleMove;
    }

    private void OnDisable()
    {
        PlayerInput.OnMove += HandleMove;
    }

    private void HandleMove(Vector2 movement)
    {
        transform.Translate(movement, Space.Self);

        //Clamp
        Vector3 position = transform.localPosition;
        position.x = Mathf.Clamp(position.x, -areaLimits.x, areaLimits.x);
        position.y = Mathf.Clamp(position.y, -areaLimits.y, areaLimits.y);
        transform.localPosition = position;
    }
}
