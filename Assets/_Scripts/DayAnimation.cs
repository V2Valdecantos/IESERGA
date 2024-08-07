using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class DayAnimation : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private TMP_Text dayText;

    private void OnEnable()
    {
        GameManager.OnTriggerDayStart += PlayAnimation;
    }

    private void OnDisable()
    {
        GameManager.OnTriggerDayStart -= PlayAnimation;
    }

    private void PlayAnimation(string text)
    {
        dayText.text = text;
        director.Play();
    }
}
