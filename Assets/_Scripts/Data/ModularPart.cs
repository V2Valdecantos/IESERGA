using System;
using UnityEngine;

public class ModularPart : MonoBehaviour
{
    [SerializeField] private ModularPart_SO data_scriptable_object;
    public static event Action<Sprite, EvidenceReason> OnPartHit;

    public void BroadcastData()
    {
        Sprite sprite = data_scriptable_object.sprite;
        EvidenceReason reason = data_scriptable_object.reason;
        OnPartHit?.Invoke(sprite, reason);
    }
}
