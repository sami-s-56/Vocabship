using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneManager : MonoBehaviour {

    static List<QuizData> WrongAnswer = new List<QuizData>();
    static int Score;

    
    public Text ScrText;

    public GameObject ScrollListItem;
    public GameObject ScrollContent;

    public static void UpdateScore()
    {
        Score = Score + 20;
    }

    public static void AddAnswer(QuizData WrngAns)
    {
        WrongAnswer.Add(WrngAns);
    }

    public Text QuesAttempted;
    static int aq, tq;
    public static void SetAttemptedQuestions(int mrks, int outoff)
    {
        aq = mrks;
        tq = outoff;
    }

    void Start()
    {
        ScrText.text = "Your Score: " + Score.ToString();
        QuesAttempted.text = "Questions Attempted: " + aq.ToString() + ": Of: " + tq.ToString();
        Debug.Log(WrongAnswer.Count);
        //Should be done in Result Scene Game Manager... Send Data and show results all at once...   
        foreach (QuizData x in WrongAnswer)
        {
            GameObject QA = Instantiate(ScrollListItem);
            QA.transform.SetParent(ScrollContent.transform, false);
            QA.transform.Find("Question").gameObject.GetComponent<Text>().text = x.question;
            QA.transform.Find("Answer").gameObject.GetComponent<Text>().text = x.answer;
        }
    }

    public void ClearResults()
    {
        Score = 0;
        WrongAnswer.Clear();
    }
}
