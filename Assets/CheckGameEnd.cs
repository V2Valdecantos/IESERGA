using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameEnd : MonoBehaviour
{
    [SerializeField] private GameObject nextPatientButton;
    [SerializeField] private GameObject gameWinButton;
    [SerializeField] private GameObject gameLoseButton;

    private void Start()
    {
        if (!GameManager.instance.IsGameEnd)
        {
            nextPatientButton.SetActive(true);
        }
        else if (GameManager.instance.IsGameWin)
        {
            gameWinButton.SetActive(true);
        }
        else 
        {
            gameLoseButton.SetActive(true);
        }
    }
}
