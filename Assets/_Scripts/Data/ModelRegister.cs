using UnityEngine;

public class ModelRegister : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private ModelType modelType;

    private void OnEnable()
    {
        NPCSpawner.instance.RegisterObject(obj, modelType);
    }

    private void OnDisable()
    {
        NPCSpawner.instance.UnregisterObject(modelType);
    }
}
