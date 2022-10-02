using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Match Image Question", fileName = "New Match Image Question")]
public class MatchQuestionSO : ScriptableObject
{
    [SerializeField] public Sprite QuestionImage;

    [TextArea(minLines: 2, maxLines: 6)]
    [SerializeField] public string QuestionText = "Enter question here";

    // 1 = JWT, 2 = Hubble
    [SerializeField] int CorrectAnswerIndex;

    [TextArea(minLines: 2, maxLines: 20)]
    [SerializeField] string CorrectAnswerDescription = "Provide correct answer knowledge here";

    public string GetQuestion()
    {
        return QuestionText;
    }

    public Sprite GetQuestionImage()
    {
        return QuestionImage;
    }

    public bool IsCorrectAnswer(int answerIndex)
    {
        return answerIndex == CorrectAnswerIndex;
    }

    public string GetCorrectAnswerDescription()
    {
        return CorrectAnswerDescription;
    }
}
