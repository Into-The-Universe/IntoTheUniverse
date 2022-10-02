using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName ="QuizQuestion", fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question text here";
    [TextArea(2, 6)]
    [SerializeField] string correctAnswerText = "";
    [TextArea(2, 6)]
    [SerializeField] string incorrectAnswerText = "";

    [SerializeField] string[] answers = new string[2];
    [SerializeField] int correctAnswerIndex;
    [SerializeField] Sprite leftButtonSprite;
    [SerializeField] Sprite rightButtonSprite;
    public string GetCorrectAnswerText()
    {
        return correctAnswerText;
    }
    public string GetIncorrectAnswerText()
    {
        return incorrectAnswerText;
    }
    public string GetQuestion()
    {
        return question;    
    }
    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
    public string GetAnswer(int index)
    {
        return answers[index];
    }
    public Sprite GetLeftButtonImage()
    {
        return leftButtonSprite;
    }
    public Sprite GetRightButtonImage()
    {
        return rightButtonSprite;
    }

    void Start()
    {
    }
}
