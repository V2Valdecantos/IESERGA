using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CameraControls playerControls;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float rotateSpeed = 100;

    public static event OnMovePerformed OnMove;
    public delegate void OnMovePerformed(Vector2 moveInput);

    public static event OnRotationPerformed OnRotate;
    public delegate void OnRotationPerformed(float theta);

    private void Awake()
    {
        if (playerControls == null)
        {
            playerControls = new CameraControls();
        }
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();
        OnMove?.Invoke(move * moveSpeed * Time.deltaTime);

        float theta = playerControls.Player.Rotate.ReadValue<float>();
        OnRotate?.Invoke(theta * rotateSpeed * Time.deltaTime);
    }


}
