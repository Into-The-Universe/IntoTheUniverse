using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int questionSeen = 0;

    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }
    public int GetQuestionsSeens()
    {
        return questionSeen;
    }

    public void IncrementCorrectAnswers() { correctAnswers++; }
    public void IncrementQuestionsSeen() { questionSeen++; }

    public int CalcuateScore()
    {
        return Mathf.RoundToInt(correctAnswers / (float)questionSeen * 100);
    }

}
