using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("ReadOnly")]
    [SerializeField] private NPC_SO data;
    [SerializeField] private GameObject model;

    public void UpdateNPC(NPC_SO data)
    {
        Destroy(model);

        this.data = data;
        model = Instantiate(data.prefab, transform);
    }
}
