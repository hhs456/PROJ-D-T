using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// 問答用的控制器
/// </summary>
public class QuestionController : MonoBehaviour
{
    public static QuestionController instance;
    public Pointable currentItem;
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;

    public QuestionData[] questions = new QuestionData[4];
    public Image[] points = new Image[4];

    [SerializeField] int keyID;

    private void Awake() {
        instance = this;
    }

    /// <summary>
    /// 觸發問題介面
    /// </summary>
    /// <param name="index">問題代號</param>
    public void TriggerQuestion(int index) {
        keyID = index;
        question.text = questions[keyID].question;
        answer1.text = questions[keyID].answer1;
        answer2.text = questions[keyID].answer2;
        answer3.text = questions[keyID].answer3;
        answer4.text = questions[keyID].answer4;
        GetComponent<Animator>().Play("Question");
    }
    /// <summary>
    /// 確認問題是否正確
    /// </summary>
    /// <param name="index"></param>
    public void CheckAnswer(int index) {
        if(questions[keyID].answer == (AnswerOption)index) {
            // 正確時將戰利品亮起
            points[keyID].color = Color.white;
            GetComponent<Animator>().Play("Hide");
        }
        else {
            // 失敗時召喚鬼魂
            GetComponent<Animator>().Play("Hide");
            Ghost.Instance.Show();
            Player.instance.animator.SetTrigger("DieForward");
            currentItem.Revive();
        }
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
