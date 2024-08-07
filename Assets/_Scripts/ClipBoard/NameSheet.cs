using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
class Evidence
{
    public bool isOccupied;
    public GameObject parent;
    public TMP_Text evidenceText;
    public Image evidenceImage;
    public GameObject correctionImage;
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
        SceneManager.sceneUnloaded += ResetSheet;
    }

    private void OnDisable()
    {
        NPCSpawner.OnSpawn -= UpdateNameAndSex;
        ModularPart.OnPartHit -= AddEvidence;
        SceneManager.sceneUnloaded -= ResetSheet;
    }

    private void Start()
    {
        foreach (Evidence evidence in evidenceList)
        {
            RemoveEvidence(evidence);
        }
    }

    public void AddEvidence(Sprite data, EvidenceReason reason)
    {
        if (CheckDuplicate(reason)) return;

        foreach (Evidence evidence in evidenceList)
        {
            if (!evidence.isOccupied)
            {
                ActivateEvidence(evidence, reason);
                evidence.evidenceImage.sprite = data;
                evidence.evidenceImage.enabled = true;
                evidence.evidenceText.enabled = false;
                return;
            }
        }
    }

    public void AddEvidence(string data, EvidenceReason reason)
    {
        if (CheckDuplicate(reason)) return;

        foreach (Evidence evidence in evidenceList)
        {
            if (!evidence.isOccupied)
            {
                ActivateEvidence(evidence, reason);
                evidence.evidenceText.text = data;
                evidence.evidenceText.enabled = true;
                evidence.evidenceImage.enabled = false;
                return;
            }
        }
    }

    private void ActivateEvidence(Evidence evidence, EvidenceReason reason)
    {
        evidence.parent.SetActive(true);
        evidence.isOccupied = true;
        evidence.reason = reason;
        evidence.correctionImage.SetActive(false);
    }

    public bool CheckDuplicate(EvidenceReason reason)
    {
        return evidenceList.Exists(evidence => evidence.reason == reason);
    }

    private void RemoveEvidence(Evidence evidence)
    {
        evidence.evidenceImage.sprite = null;
        evidence.evidenceImage.enabled = false;
        evidence.evidenceText.text = "";
        evidence.evidenceText.enabled = false;
        evidence.correctionImage.SetActive(false);
        evidence.isOccupied = false;
        evidence.reason = EvidenceReason.NONE;
    }

    public void UpdateNameAndSex(string name, string sex)
    {
        sheetName.text = name;
        sheetSex.text = sex;
    }

    public void SubmitNameSheet()
    {
        List<Evidence> reasonList = new List<Evidence>(evidenceList.Count);

        foreach (Evidence evidence in evidenceList)
        {
            if (evidence.reason != EvidenceReason.NONE)
            {
                reasonList.Add(evidence);
            }
        }

        CheckSubmission((TannerStages)dropdown.value, reasonList);
        FindAnyObjectByType<SceneLoader>().LoadResultsScreen();
    }

    private void CheckSubmission(TannerStages verdict, List<Evidence> reasons)
    {
        verdictCorrection.enabled = true;
        verdictCorrection.sprite = NPCSpawner.instance.CurrentTannerStage == verdict ? checkMark : crossMark;
        verdictCorrection.color = NPCSpawner.instance.CurrentTannerStage == verdict ? Color.green : Color.red;

        List<EvidenceReason> correctReasons = NPCSpawner.instance.CurrentReasonsList;
        HashSet<EvidenceReason> currentReasons = new HashSet<EvidenceReason>(reasons.ConvertAll(e => e.reason));

        GameManager.instance.SetCount(reasons.Count);

        foreach (EvidenceReason correctReason in correctReasons)
        {
            if (!currentReasons.Contains(correctReason))
            {
                foreach (Evidence slot in evidenceList)
                {
                    if (!slot.isOccupied)
                    {
                        ActivateEvidence(slot, EvidenceReason.NONE);
                        slot.correctionImage.SetActive(true);
                        slot.evidenceText.enabled = false;
                        slot.evidenceImage.enabled = false;
                        break;
                    }
                }
            }
        }
    }

    public bool CheckVerdict()
    {
        return NPCSpawner.instance.CurrentTannerStage == (TannerStages)dropdown.value ? true : false;
    }

    private void ResetSheet(Scene scene)
    {
        if (scene.name == SceneNames.end_screen)
        {
            foreach (Evidence evidence in evidenceList)
            {
                RemoveEvidence(evidence);
            }

            verdictCorrection.enabled = false;
            dropdown.value = 0;
        }
    }
}
