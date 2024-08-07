using JetBrains.Annotations;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public enum GameLevel : int 
{
    NONE = -1,
    LEVEL_1 = 0,
    LEVEL_2,
    LEVEL_3,
    LEVEL_4,
    LEVEL_5,
}

public enum GamePhase : int
{
    NONE = -1,
    PHASE_1 = 0,
    PHASE_2,
    PHASE_3,
    PHASE_4,
    PHASE_5
}

public class GameManager : MonoBehaviour
{
    [Header("Fill Up")]
    [SerializeField] private NPCSpawner spawner;
    [SerializeField] private NameSheet nameSheet;

    [SerializeField] private int maxFails = 3;
    [SerializeField] private int maxLevels = 5;
    [SerializeField] private int maxPhases = 5;

    [Header("ReadOnly")]
    [SerializeField] private GameLevel currentLevel = GameLevel.LEVEL_1;
    [SerializeField] private GamePhase currentPhase = GamePhase.PHASE_1;

    [SerializeField] private int numberOfFails = 0;
    [SerializeField] private bool isTriggerStartOfDayAnimation = true;
    [SerializeField] private bool isGameEnd = false;
    [SerializeField] private bool isGameWin = false;
    [SerializeField] private int score = 0;
    private int count = 0;

    public static GameManager instance;

    public static event Action<string> OnTriggerDayStart;

    public bool IsGameEnd => isGameEnd;
    public bool IsGameWin => isGameWin;

    public int Score => score;

    private void Awake()
    {
        InitializeSingleton();
    }

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
        if (nameSheet == null || spawner == null)
        {
            Debug.LogError("Dependencies not set in the Inspector.");
            return;
        }

        switch (scene.name)
        {
            case SceneNames.end_screen:
                HandleEndScene();
                break;

            case SceneNames.conversation_scene:
                HandleConversationScene();
                break;

            case SceneNames.title_screen:
                Destroy(gameObject); 
                break;

            default:
                break;
        }
    }

    private void HandleEndScene()
    {
        if (nameSheet.CheckVerdict())
        {
            ScoreSubmission();
            IncrementPhase();
        }
        else
        {
            HandleFailure();
        }
    }

    private void ScoreSubmission()
    {
        int correctReasons = NPCSpawner.instance.CurrentReasonsList.Count;
        int correctCount = count;
        score += 50;
        score += (correctCount * 50) / correctReasons;
    }

    public void SetCount(int count)
    {
        this.count = count;
    }

    private void HandleConversationScene()
    {
        if (isTriggerStartOfDayAnimation)
        {
            OnTriggerDayStart?.Invoke("Day " + ((int)currentLevel + 1));
            isTriggerStartOfDayAnimation = false;
        }
    }

    private void HandleFailure()
    {
        numberOfFails++;
        if (numberOfFails >= maxFails)
        {
            isGameEnd = true;
            isGameWin = false;
        }
        else
        {
            IncrementPhase();
        }
    }

    private void IncrementPhase()
    {
        if ((int)currentPhase < maxPhases - 1)
        {
            currentPhase++;
        }
        else
        {
            IncrementLevel();
        }

        spawner.SetNPC((int)currentLevel * (maxPhases - 1) + (int)currentPhase);
    }

    private void IncrementLevel()
    {
        if ((int)currentLevel < maxLevels - 1)
        {
            currentLevel++;
            currentPhase = GamePhase.PHASE_1;
            isTriggerStartOfDayAnimation = true;

            /* reset failures */
            numberOfFails = 0;
        }
        else
        {
            isGameEnd = true;
            isGameWin = true;
        }
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
