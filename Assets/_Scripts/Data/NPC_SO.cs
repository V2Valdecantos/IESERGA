using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data_NPC", menuName = "Data Scriptable Object/NPC", order = 2)]
public class NPC_SO : ScriptableObject
{
    public GameObject prefab;
    public List<EvidenceReason> reasonsList;
}
