using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickableSymptoms : MonoBehaviour
{
    [SerializeField] private GameObject _tooltip;
    [SerializeField] private float tooltipDuration = 2.0f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this._tooltip.activeSelf == true)
        {  
            if (this.timer >= tooltipDuration)
            {
                this._tooltip.SetActive(false);
                this.timer = 0.0f; 
            }
            else
            {
                this.timer += Time.deltaTime;
            }
        }
    }

    public void DisplayTooltip()
    {
        if (this._tooltip != null)
        {
            this._tooltip.SetActive(true);
        }
    }

    public void AddToDictionary()
    {
        string symptomName = this.gameObject.name;

        //Call dictionary here
    }
}
