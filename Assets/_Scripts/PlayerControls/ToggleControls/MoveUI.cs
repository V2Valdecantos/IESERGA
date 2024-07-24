using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public enum UIState : int 
{
    NONE = -1,
    POSITION_1 = 1,
    POSITION_2,
}

public class MoveUI : MonoBehaviour
{
    [Header("Set Values")]
    [SerializeField] private List<Vector2> positions;
    [SerializeField] private float animationTime = 0.5f;
    [SerializeField] private RectTransform rectTransform;

    [Header("ReadOnly")]
    [Tooltip("ReadOnly")][SerializeField] private UIState state = UIState.POSITION_1;
    [Tooltip("ReadOnly")][SerializeField] private bool isMoving = false;

    private void Awake()
    {
        if (rectTransform == null)
        {
            Debug.LogError("Rect Transform Missing!");
        }
    }

    private void Start()
    {
        rectTransform.localPosition = positions[0];
    }

    public void TogglePosition()
    {
        if (isMoving) { return; }

        isMoving = true;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        Vector2 startPosition = rectTransform.localPosition;
        Vector2 endPosition;
        float elapsedTime = 0f;

        switch (state)
        {
            case UIState.POSITION_1:
                endPosition = positions[1];
                state = UIState.POSITION_2;
                break;

            case UIState.POSITION_2:
                endPosition = positions[0];
                state = UIState.POSITION_1;
                break;

            default:
                isMoving = false;
                yield break;
        }

        while (elapsedTime < animationTime)
        {
            rectTransform.localPosition = Vector2.Lerp(startPosition, endPosition, elapsedTime / animationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.localPosition = endPosition;
        isMoving = false;
    }
}
