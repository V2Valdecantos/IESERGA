using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipBoard : MonoBehaviour
{
    [SerializeField] private MoveClipBoard script;
    [SerializeField] private List<GameObject> controlButtons;
    [SerializeField] private List<GameObject> pages;
    private GameObject activeButton;
    private GameObject activePage;

    private static ClipBoard instance;

    private void Awake()
    {
        InitializeSingleton();
        activeButton = controlButtons[0];
        activePage = pages[0];
    }

    private void OnEnable()
    {
        PlayerInput.OnToggleClipBoard += ToggleClipBoard;
    }

    private void ToggleClipBoard()
    {
        script.TogglePosition();
    }

    public void OpenPage(int index)
    {
        if (index < 0 || index > controlButtons.Count)
        {
            Debug.LogError("index our of range!");
        }

        Image img;

        activePage.SetActive(false);
        activeButton.TryGetComponent(out img);

        if (img == null)
        {
            Debug.LogError("Button Missing!");
            return;
        }

        img.fillAmount = 0.85f;

        activeButton = controlButtons[index];
        activePage = pages[index];

        activeButton.TryGetComponent(out img);

        if (img == null)
        {
            Debug.LogError("Button Missing!");
            return;
        }

        img.fillAmount = 1;
        activePage.SetActive(true);
    }

    private void InitializeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
