using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private List<NPC_SO> dataNPC;

    [Header("ReadOnly")]
    [SerializeField] private Transform conversationTransform;
    [SerializeField] private Transform examineBlurredTransform;
    [SerializeField] private Transform examineZoomedTransform;
    [SerializeField] private string currentLoadedScene;

    [SerializeField] private int currentNPC = 0;

    public static event Action<string, string> OnSpawn;
    public static NPCSpawner instance;
    public List<EvidenceReason> CurrentReasonsList => dataNPC[currentNPC].ReasonsList;
    public TannerStages CurrentTannerStage => dataNPC[currentNPC].TannerStage;

    private void Awake()
    {
        InitializeSingleton();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentLoadedScene = scene.name;
        SetObjectParentTransform();
        SpawnNPC();
    }

    private void SpawnNPC()
    {
        OnSpawn?.Invoke(dataNPC[currentNPC].NameNPC, dataNPC[currentNPC].SexNPC);

        switch (currentLoadedScene)
        {
            case SceneNames.examine_scene:
                Instantiate(dataNPC[currentNPC].ZoomedModel, examineZoomedTransform);
                Instantiate(dataNPC[currentNPC].BlurredModel, examineBlurredTransform);
                break;
            case SceneNames.conversation_scene:
                Instantiate(dataNPC[currentNPC].TalkingModel, conversationTransform);
                break;
            case SceneNames.end_screen:
            case SceneNames.title_screen:
                return;
            default:
                Debug.LogError("Current Scene is Unknown");
                break;
        }
    }

    private void SetObjectParentTransform()
    {
        switch (currentLoadedScene)
        {
            case SceneNames.conversation_scene:
                conversationTransform = GameObject.FindWithTag(TagNames.conversation_slot).transform;
                break;
            case SceneNames.examine_scene:
                examineBlurredTransform = GameObject.FindWithTag(TagNames.blurred_slot).transform;
                examineZoomedTransform = GameObject.FindWithTag(TagNames.zoomed_slot).transform;
                break;
            case SceneNames.end_screen:
            case SceneNames.title_screen:
                Destroy(gameObject);
                return;
            default:
                Debug.LogError("Current Scene is Unknown");
                break;
        }
    }

    public void SetNPC(int index)
    {
        if (index < 0 || index > dataNPC.Count)
        {
            Debug.LogError("NPC DATA MISSING \n INDEX OUT OF BOUNDS");
            return;
        }

        currentNPC = index;
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


