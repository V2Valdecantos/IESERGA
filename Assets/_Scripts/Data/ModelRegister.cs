using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelRegister : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private List<GameObject> zoomedModels;
    [SerializeField] private ModelType modelType;

    private void OnEnable()
    {
        if (modelType == ModelType.MALE_ZOOMED)
        {
            zoomedModels[NPCSpawner.instance.CurrentNPC].SetActive(true);
            NPCSpawner.instance.RegisterObject(zoomedModels[NPCSpawner.instance.CurrentNPC], modelType);
        }
        else
        {
            NPCSpawner.instance.RegisterObject(obj, modelType);
        }
    }

    private void OnDisable()
    {
        if (modelType == ModelType.MALE_ZOOMED)
        {
            NPCSpawner.instance.UnregisterObject(modelType);
            zoomedModels[NPCSpawner.instance.CurrentNPC].SetActive(false);
        }
        else
        {
            NPCSpawner.instance.UnregisterObject(modelType);
        }
    }
}
