using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(minLines: 2, maxLines: 6)]
    [SerializeField] string Question = "Enter new question text here";

    [SerializeField] string[] Answers = new string[3];
    [SerializeField] int CorrectAnswerIndex;

    [TextArea(minLines: 2, maxLines: 20)]
    [SerializeField] string CorrectAnswerDescription = "Provide correct answer knowledge here";

    public string GetQuestion()
    {
        return Question;
    }

    public int GetCorrectAnswerIndex()
    {
        return CorrectAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return Answers[index];
    }

    public string GetCorrectAnswerDescription()
    {
        return CorrectAnswerDescription;
    }
}
