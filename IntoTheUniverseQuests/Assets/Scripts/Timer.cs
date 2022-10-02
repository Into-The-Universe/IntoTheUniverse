using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 5f;
    [SerializeField] float timeToShowCorrectAnswer = 3f;

    public bool LoadNextQuestion;
    public bool IsAnsweringQuestion = false;
    public float FillFraction;
    public bool StopTimer = false;

    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    private void UpdateTimer()
    {
        if (StopTimer) return;

        timerValue -= Time.deltaTime;

        if (IsAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                FillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                IsAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue <= 0)
            {
                IsAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                LoadNextQuestion = true;
            }
            else
            {
                FillFraction = timerValue / timeToShowCorrectAnswer;
            }

        }
    }
}
