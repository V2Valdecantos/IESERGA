using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUINameSheet : MonoBehaviour
{
    [SerializeField] private MoveUI script;

    private void OnEnable()
    {
        PlayerInput.OnToggleNameSheet += Toggle;
    }

    private void Toggle()
    {
        script.TogglePosition();
    }
}
