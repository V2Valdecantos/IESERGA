using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
class Evidence
{
    public bool isOccupied;
    public GameObject parent;
    public TMP_Text evidenceText;
    public Image evidenceImage;
    public Image correctionImage;
    public EvidenceReason reason;
}

public class NameSheet : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_Text sheetName;
    [SerializeField] private TMP_Text sheetSex;
    [SerializeField] private List<Evidence> evidenceList;
    [SerializeField] private Image verdictCorrection;

    [Header("End Screen Sprites")]
    [SerializeField] private Sprite checkMark;
    [SerializeField] private Sprite crossMark;

    private void OnEnable()
    {
        NPCSpawner.OnSpawn += UpdateNameAndSex;
        ModularPart.OnPartHit += AddEvidence;
    }

    private void OnDisable()
    {
        NPCSpawner.OnSpawn -= UpdateNameAndSex;
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
                evidence.correctionImage.enabled = false;

                /* Set Image */
                evidence.evidenceImage.sprite = data;
                evidence.evidenceImage.enabled = true;
                /* Disable Other Evidence Type */
                evidence.evidenceText.enabled = false;

                return;
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
                evidence.correctionImage.enabled = false;

                /* Set Text */
                evidence.evidenceText.text = data;
                evidence.evidenceText.enabled = true;
                /* Disable Other Evidence Type */
                evidence.evidenceImage.enabled = false;

                return;
            }
        }
    }

    public bool CheckDuplicate(EvidenceReason reason)
    {
        Debug.Log("Check");
        foreach (Evidence evidence in evidenceList)
        {
            if (evidence.reason == reason)
            {
                Debug.Log("Found");
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
        evidenceList[index].evidenceImage.sprite = null;
        evidenceList[index].evidenceImage.enabled = true;
        evidenceList[index].evidenceText.text = "";
        evidenceList[index].evidenceText.enabled = true;
        evidenceList[index].correctionImage.enabled = true;


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
        List<Evidence> reasonList = new List<Evidence>();

        foreach (Evidence evidence in evidenceList)
        {
            if (evidence.reason != EvidenceReason.NONE)
            {
                reasonList.Add(evidence);
            }
        }

        CheckSubmission((TannerStages)value, reasonList);
        FindAnyObjectByType<SceneLoader>().LoadResultsScreen();
    }

    private void CheckSubmission(TannerStages verdict, List<Evidence> reasons)
    {
        if (NPCSpawner.instance.CurrentTannerStage == verdict)
        {
            verdictCorrection.enabled = true;
            verdictCorrection.sprite = checkMark;
            verdictCorrection.color = Color.green;
        }
        else
        {
            verdictCorrection.enabled = true;
            verdictCorrection.sprite = crossMark;
            verdictCorrection.color = Color.red;
        }

        List<EvidenceReason> correctReasons = NPCSpawner.instance.CurrentReasonsList;

        foreach (Evidence evidence in reasons)
        {
            evidence.correctionImage.enabled = true;

            if (correctReasons.Contains(evidence.reason))
            {      
                evidence.correctionImage.sprite = checkMark;
                evidence.correctionImage.color = Color.green;
            }
            else
            {
                evidence.correctionImage.sprite = crossMark;
                evidence.correctionImage.color = Color.red;
            }
        }
    }

}
