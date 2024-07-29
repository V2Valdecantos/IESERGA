using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PositionState : int 
{
    NONE = -1,
    START = 1,
    END,
}

public class MoveNameSheet : MonoBehaviour
{
    [Header("Set Values")]
    [SerializeField] private List<Vector3> positions;
    [SerializeField] private float animationTime = 0.5f;

    [Header("ReadOnly")]
    [Tooltip("ReadOnly")][SerializeField] private PositionState state = PositionState.START;
    [Tooltip("ReadOnly")][SerializeField] private bool isMoving = false;

    private void Start()
    {
        transform.localPosition = positions[0];
    }

    public void TogglePosition()
    {
        if (isMoving) { return; }

        isMoving = true;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        Vector3 startPosition = transform.localPosition;
        Vector3 endPosition;
        float elapsedTime = 0f;

        switch (state)
        {
            case PositionState.START:
                endPosition = positions[1];
                state = PositionState.END;
                break;

            case PositionState.END:
                endPosition = positions[0];
                state = PositionState.START;
                break;

            default:
                isMoving = false;
                yield break;
        }

        while (elapsedTime < animationTime)
        {
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime / animationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = endPosition;
        isMoving = false;
    }
}
