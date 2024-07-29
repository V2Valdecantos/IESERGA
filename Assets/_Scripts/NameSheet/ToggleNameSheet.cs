using UnityEngine;

public class ToggleNameSheet : MonoBehaviour
{
    [SerializeField] private MoveNameSheet script;

    private void OnEnable()
    {
        PlayerInput.OnToggleNameSheet += Toggle;
    }

    private void Toggle()
    {
        script.TogglePosition();
    }
}
