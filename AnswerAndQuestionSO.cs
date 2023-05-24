using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question 1", menuName = "ScriptableObjects/Q&A")]
public class AnswerAndQuestionSO : ScriptableObject
{
    public string question;
    public string wrongA;
    public string wrongB;
    public string wrongC;
    public string answer;
}
