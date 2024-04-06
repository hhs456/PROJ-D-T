using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;

    public QuestionData[] questions = new QuestionData[4];
    
    public void TriggerQuestion(int index) {
        question.text = questions[index].question;
        question.text = questions[index].question;
        question.text = questions[index].question;
        question.text = questions[index].question;
        question.text = questions[index].question;
    }
}

[Serializable]
public class QuestionData {
    [TextArea] public string question;
    public AnswerOption answer;
    [FormerlySerializedAs("anser1")]
    public string answer1;
    [FormerlySerializedAs("anser2")]
    public string answer2;
    [FormerlySerializedAs("anser3")]
    public string answer3;
    [FormerlySerializedAs("anser4")]
    public string answer4;
}

public enum AnswerOption {
    A, B, C, D
}
