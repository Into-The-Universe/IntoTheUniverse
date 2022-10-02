using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] TextMeshProUGUI answerText;
    bool hasAnsweredEarly;

    [Header("Timer")]
    [SerializeField] Image TimerImage;
    Timer timer;

    [Header("Button Colours")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    private int numberCorrectAnswers = 0;

    void Start()
    {
        timer = FindObjectOfType<Timer>();

        GetNextQuestion();
    }

    private void Update()
    {
        TimerImage.fillAmount = timer.FillFraction; 
        if (questions.Count <= 0)
        {
            timer.StopTimer = true;
        }
        else if (timer.LoadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.LoadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.IsAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;
        var correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();

        if (index == correctAnswerIndex)
        {
            questionText.text = "Correct!";
            answerText.text = currentQuestion.GetCorrectAnswerDescription();
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            SetButtonState(false);
            numberCorrectAnswers++;
        }
        else
        {
            questionText.text = "Wrong!";
            answerText.text = currentQuestion.GetCorrectAnswerDescription();
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    private void RenderQuestion()
    {
        answerText.text = string.Empty;
        questionText.text = currentQuestion.GetQuestion();

        for (var index = 0; index < answerButtons.Length; index++)
        {
            var buttonText = answerButtons[index].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(index);
        }
    }

    private void SetButtonState(bool interactable)
    {
        for (int index = 0; index < answerButtons.Length; index++)
        {
            var button = answerButtons[index].GetComponent<Button>();
            button.interactable = interactable;
        }
    }

    private void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprite();
        GetRandomQuestion();
        RenderQuestion();
    }

    private void GetRandomQuestion()
    {
        var index = UnityEngine.Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    private void SetDefaultButtonSprite()
    {
        foreach (var button in answerButtons)
        {
            button.GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }
}