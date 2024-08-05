using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExamineInput : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    [SerializeField] private Camera scanCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        ray = scanCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))

        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<ClickableSymptoms>() != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        hit.collider.gameObject.GetComponent<ClickableSymptoms>().DisplayTooltip();
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Nothing there...");
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Nothing there...");
                }
            }
        }
    }

}
