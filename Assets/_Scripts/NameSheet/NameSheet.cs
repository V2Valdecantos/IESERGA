using System;
using System.Collections.Generic;   
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum EvidenceReason : int 
{
    NONE = -1,
    TEST_1 = 0,
    TEST_2 = 1,
}

[Serializable]
class Evidence
{
    public bool isOccupied;
    public GameObject parent;
    public Image image;
    public TMP_Text text;
    public EvidenceReason reason;
}

public class NameSheet : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_Text sheetName;
    [SerializeField] private TMP_Text sheetSex;
    [SerializeField] private List<Evidence> evidenceList;

    public static event Action<int> OnNameSheetSubmit;

    private void OnEnable()
    {
        ModularPart.OnPartHit += AddEvidence;
    }

    private void OnDisable()
    {
        ModularPart.OnPartHit -= AddEvidence;
    }

    private void Start()
    {
        for (int i = 0; i < evidenceList.Count; i++)
        {
            RemoveEvidence(i);
        }
    }

    public void AddEvidence(Sprite data, EvidenceReason reason)
    {
        if (CheckDuplicate(reason)) { return; }

        foreach (Evidence evidence in evidenceList)
        {
            if (!evidence.isOccupied)
            {
                evidence.parent.SetActive(true);
                evidence.isOccupied = true;
                evidence.reason = reason;

                /* Set Image */
                evidence.image.sprite = data;
                evidence.image.enabled = true;
                /* Disable Other Evidence Type */
                evidence.text.enabled = false;
            }
        }
    }

    public void AddEvidence(string data, EvidenceReason reason)
    {
        if (CheckDuplicate(reason)) { return; }

        foreach (Evidence evidence in evidenceList)
        {
            if (!evidence.isOccupied)
            {
                evidence.parent.SetActive(true);
                evidence.isOccupied = true;
                evidence.reason = reason;

                /* Set Text */
                evidence.text.text = data;
                evidence.text.enabled = true;
                /* Disable Other Evidence Type */
                evidence.image.enabled = false;

                return;
            }
        }
    }

    public bool CheckDuplicate(EvidenceReason reason)
    {
        foreach (Evidence evidence in evidenceList)
        {
            if (evidence.reason == reason)
            {
                return true;
            }
        }

        return false;
    }

    public void RemoveEvidence(int index)
    {

        if (index < 0 && index > evidenceList.Count)
        {
            Debug.LogError("Index Out Of Bounds");
            return; 
        }

        /* Reset Holders */
        evidenceList[index].image.enabled = true;
        evidenceList[index].image.sprite = null;
        evidenceList[index].text.enabled = true;
        evidenceList[index].text.text = "";

        /* Reset Data */
        evidenceList[index].isOccupied = false;
        evidenceList[index].reason = EvidenceReason.NONE;

        evidenceList[index].parent.SetActive(false); 
    }

    public void UpdateNameAndSex(string name, string sex)
    {
        sheetName.text = name;
        sheetSex.text = sex;
    }

    public void SubmitNameSheet()
    {
        int value = dropdown.value;
        OnNameSheetSubmit?.Invoke(value);
    }

}
