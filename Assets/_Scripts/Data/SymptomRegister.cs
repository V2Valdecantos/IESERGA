using UnityEngine;

public class SymptomRegister : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private EvidenceReason symptom;

    private void OnEnable()
    {
        NPCSpawner.instance.RegisterObject(obj, symptom);
    }

    private void OnDisable()
    {
        NPCSpawner.instance.UnregisterObject(symptom);
    }
}

