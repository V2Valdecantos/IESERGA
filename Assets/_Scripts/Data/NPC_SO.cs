using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data_NPC", menuName = "Data Scriptable Object/NPC", order = 2)]
public class NPC_SO : ScriptableObject
{
    [SerializeField] private GameObject talkingModel;
    [SerializeField] private GameObject blurredModel;
    [SerializeField] private GameObject zoomedModel;
    [SerializeField] private TannerStages tannerStage;
    [SerializeField] private List<EvidenceReason> reasonsList;
    [SerializeField] private string nameNPC;
    [SerializeField] private string sexNPC;

    public GameObject TalkingModel => talkingModel;
    public GameObject BlurredModel => blurredModel; 
    public GameObject ZoomedModel => zoomedModel;
    public TannerStages TannerStage => tannerStage;
    public List<EvidenceReason> ReasonsList => reasonsList;
    public string NameNPC => nameNPC;
    public string SexNPC => sexNPC;
}
