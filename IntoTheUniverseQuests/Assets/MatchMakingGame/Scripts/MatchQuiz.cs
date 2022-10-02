using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchQuiz : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] Image playerImage;

    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] Image questionImage;
    [SerializeField] List<MatchQuestionSO> questions = new List<MatchQuestionSO>();
    int totalQuestions = 0;
    MatchQuestionSO currentQuestion;

    [Header("Answer")]
    [SerializeField] TextMeshProUGUI correctText;
    [SerializeField] TextMeshProUGUI wrongText;

    bool gameOver = false;
    bool alreadyAnswered = true;

    [SerializeField] TextMeshProUGUI scoreText;

    private int numberCorrectAnswers = 0;

    void Start()
    {
        totalQuestions = questions.Count;
        GetNextQuestion();
    }

    private void Update()
    {
        if (gameOver) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !alreadyAnswered)
        {
            playerImage.transform.localRotation = Quaternion.Euler(0, 180,0);
            
            if (currentQuestion.IsCorrectAnswer(1))
            {
                numberCorrectAnswers++;
                alreadyAnswered = true;
                correctText.enabled = true;
            }
            else
            {
                wrongText.enabled = true;
            }

            DisplayAnswer();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && !alreadyAnswered)
        {
            playerImage.transform.localRotation = Quaternion.Euler(0, 0, 0);

            if (currentQuestion.IsCorrectAnswer(2))
            {
                numberCorrectAnswers++;
                alreadyAnswered = true;
                correctText.enabled = true;
            }
            else
            {
                wrongText.enabled = true;
            }

            DisplayAnswer();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetNextQuestion();
        }
    }

    private void DisplayAnswer()
    {
        var answerDescription = currentQuestion.GetCorrectAnswerDescription();
        if (string.IsNullOrEmpty(answerDescription)) return;

        questionText.text = answerDescription;
        questionImage.enabled = false;

        scoreText.text = $"Score {numberCorrectAnswers}/{totalQuestions}";
    }

    private void GetNextQuestion()
    {
        if (questions.Count < 1)
        {
            gameOver = true;
            return;
        };

        GetRandomQuestion();
        RenderQuestion();
    }

    private void GetRandomQuestion()
    {
        var index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    private void RenderQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();
        questionImage.enabled = true;
        questionImage.sprite = currentQuestion.GetQuestionImage();

        alreadyAnswered = false;
        correctText.enabled = false;
        wrongText.enabled = false;
    }
}
