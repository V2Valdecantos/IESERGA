using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PositionState : int 
{
    NONE = -1,
    START = 1,
    END,
}

public class MoveClipBoard : MonoBehaviour
{
    [Header("Set Values")]
    [SerializeField] private List<Vector3> positions;
    [SerializeField] private float animationTime = 0.5f;
    [SerializeField] private Vector3 centered;

    [Header("ReadOnly")]
    [SerializeField] private string currentScene;
    [Tooltip("ReadOnly")][SerializeField] private PositionState state = PositionState.START;
    [Tooltip("ReadOnly")][SerializeField] private bool isMoving = false;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += GetCurrentScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= GetCurrentScene;
    }

    private void GetCurrentScene(Scene scene, LoadSceneMode mode) 
    {
        currentScene = scene.name;

        switch (currentScene)
        {
            case SceneNames.conversation_scene:
                transform.localPosition = positions[0];
                state = PositionState.START;
                break;

            case SceneNames.examine_scene:
                transform.localPosition = positions[2];
                state = PositionState.START;
                break;

            case SceneNames.end_screen:
                transform.localPosition = centered;
                break;

            case SceneNames.title_screen:
                Destroy(gameObject);
                break;

            default:
                Debug.LogError($"Unknown Scene Loaded {currentScene}");
                break;
        }
    }

    public void TogglePosition()
    {
        if (isMoving) { return; }

        isMoving = true;

        switch (currentScene)
        {
            case SceneNames.conversation_scene:
                StartCoroutine(MoveUsingSet1());
                break;

            case SceneNames.examine_scene:
                StartCoroutine(MoveUsingSet2());
                break;
        }
        
    }

    IEnumerator MoveUsingSet1()
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

    IEnumerator MoveUsingSet2()
    {
        Vector3 startPosition = transform.localPosition;
        Vector3 endPosition;
        float elapsedTime = 0f;

        switch (state)
        {
            case PositionState.START:
                endPosition = positions[3];
                state = PositionState.END;
                break;

            case PositionState.END:
                endPosition = positions[2];
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
