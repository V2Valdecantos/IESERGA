using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetRating : MonoBehaviour
{
    [SerializeField] private TMP_Text text; 
    void Start()
    {
        text.text = $"Rating: {GameManager.instance.Score}";
    }
}
