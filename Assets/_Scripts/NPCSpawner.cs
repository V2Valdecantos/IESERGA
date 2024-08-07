using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private List<NPC_SO> dataNPC;

    [Header("ReadOnly")]
    [SerializeField] private string currentLoadedScene;
    [SerializeField] private int currentNPC = 0;
    [SerializeField] private GameObject male_model;

    private Dictionary<ModelType, GameObject> modelList = new Dictionary<ModelType, GameObject>();
    private Dictionary<EvidenceReason, GameObject> symptomsList = new Dictionary<EvidenceReason, GameObject>();
    public static event Action<string, string> OnSpawn;
    public static NPCSpawner instance;
    public List<EvidenceReason> CurrentReasonsList => dataNPC[currentNPC].ReasonsList;
    public TannerStages CurrentTannerStage => dataNPC[currentNPC].TannerStage;

    private void Awake()
    {
        InitializeSingleton();
        if (male_model != null)
            this.RegisterObject(male_model, ModelType.MALE_NORMAL);
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
        SpawnNPC();
    }

    private void SpawnNPC()
    {
        OnSpawn?.Invoke(dataNPC[currentNPC].NameNPC, dataNPC[currentNPC].SexNPC);

        switch (currentLoadedScene)
        {
            case SceneNames.examine_scene:
                SpawnExamine();
                SpawnSymptoms();
                break;
            case SceneNames.conversation_scene:
                SpawnNormal();
                break;
            case SceneNames.end_screen:
                break;
            case SceneNames.title_screen:
                Destroy(gameObject);
                return;
            default:
                Debug.LogError("Current Scene is Unknown");
                break;
        }
    }

    private void SpawnNormal()
    {
        switch(dataNPC[currentNPC].SexNPC)
        {
            case "F":
                modelList[ModelType.FEMALE_NORMAL].SetActive(true);
                break;

            case "M":
                modelList[ModelType.MALE_NORMAL].SetActive(true);
                break;

            default:
                Debug.LogError("Spawning ERROR");
                break;
        }
    }

    private void SpawnExamine()
    {
        switch (dataNPC[currentNPC].SexNPC)
        {
            case "F":
                modelList[ModelType.FEMALE_BLURRED].SetActive(true);
                modelList[ModelType.FEMALE_ZOOMED].SetActive(true);
                break;

            case "M":
                modelList[ModelType.MALE_BLURRED].SetActive(true);
                modelList[ModelType.MALE_ZOOMED].SetActive(true);
                break;

            default:
                Debug.LogError("Spawning ERROR");
                break;
        }
    }

    private void SpawnSymptoms()
    {
        List<EvidenceReason> reasonsList = dataNPC[currentNPC].ReasonsList;

        foreach (EvidenceReason reason in reasonsList)
        {
            symptomsList[reason].SetActive(true);
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

    public void RegisterObject(GameObject obj, EvidenceReason type)
    {
        symptomsList.Add(type, obj);
    }

    public void RegisterObject(GameObject obj, ModelType type)
    {
        modelList.Add(type, obj);
    }

    public void UnregisterObject(EvidenceReason type)
    {
        symptomsList.Remove(type);
    }

    public void UnregisterObject(ModelType type)
    {
        modelList.Remove(type);
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


