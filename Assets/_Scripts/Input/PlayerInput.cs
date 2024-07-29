using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CameraControls playerControls;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float rotateSpeed = 100;

    public static event Action<Vector2> OnMove;
    public static event Action<float> OnRotate;

    public static event Action OnToggleNameSheet;
    public static event Action OnFire;

    private void Awake()
    {
        if (playerControls == null)
        {
            playerControls = new CameraControls();
        }
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new CameraControls();
        }

        playerControls.Enable();
        playerControls.Player.ToggleNameSheet.performed += HandleToggleNameSheet;
        playerControls.Player.Fire.performed += HandleFirePerformed;
    }

    private void OnDisable()
    {
        if (playerControls != null)
        {
            playerControls.Player.ToggleNameSheet.performed -= HandleToggleNameSheet;
            playerControls.Player.Fire.performed -= HandleFirePerformed;
            playerControls.Disable();
        }
    }

    private void HandleToggleNameSheet(InputAction.CallbackContext context) => OnToggleNameSheet?.Invoke();
    private void HandleFirePerformed(InputAction.CallbackContext context) => OnFire?.Invoke();

    private void FixedUpdate()
    {
        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();
        OnMove?.Invoke(move * moveSpeed * Time.deltaTime);

        float theta = playerControls.Player.Rotate.ReadValue<float>();
        OnRotate?.Invoke(theta * rotateSpeed * Time.deltaTime);
    }

    public void RaycastState(bool state)
    {
        if (state)
        {
            playerControls.Player.Fire.Enable();
        }
        else
        {
            playerControls.Player.Fire.Disable();
        }
    }
}
