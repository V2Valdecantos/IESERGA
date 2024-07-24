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

    private static PlayerInput instance;

    private void Awake()
    {
        InitializeSingleton();

        if (playerControls == null)
        {
            playerControls = new CameraControls();
        }
    }

    private void OnEnable()
    {
        playerControls.Enable();

        playerControls.Player.ToggleNameSheet.performed += HandleToggleNameSheet;
    }

    private void OnDisable()
    {
        playerControls.Disable();

        playerControls.Player.ToggleNameSheet.performed -= HandleToggleNameSheet;
    }

    private void HandleToggleNameSheet(InputAction.CallbackContext context) => OnToggleNameSheet?.Invoke();

    private void FixedUpdate()
    {
        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();
        OnMove?.Invoke(move * moveSpeed * Time.deltaTime);

        float theta = playerControls.Player.Rotate.ReadValue<float>();
        OnRotate?.Invoke(theta * rotateSpeed * Time.deltaTime);
    }



    private void InitializeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
