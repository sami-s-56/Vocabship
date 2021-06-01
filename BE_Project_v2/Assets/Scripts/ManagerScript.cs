using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



//Main Game Scene Manager
public class ManagerScript : MonoBehaviour {

    //Variables
    static QuizData[] qd;
    private static List<QuizData> RemainingQuestions;
    static string mode;
    static string level;
    static int flag = 0;
    static int TotalQues;

    //Question and Answers variable
    string quest;
    string crrans;
    

	// Use this for initialization
	void Start () {
        
        //Maintain List of Remaining Questions and load data (only once in game)
        if (flag == 0)
        {
            GameObject.Find("GameManager").GetComponent<DataManager>().SetData(mode, level);
            qd = GameObject.Find("GameManager").GetComponent<DataManager>().GetData();
            RemainingQuestions = qd.ToList<QuizData>();
            flag = 1;

            

            TotalQues = qd.Length;
        }

        //Get random question from the unanswered questions list and remove it
        //simultanously load another 4 random answers

        if (RemainingQuestions[0].question == null)
        {
            Debug.Log("Working and not working");
            StartManager.NoDataFound();
            SceneManager.LoadScene("StartUI");
        }
        else
        {
            OnNext();
        }
        //OnNext();
        
        
        
	}
    

    public static void SetMdLvl(string md,string lvl)
    {
        mode = md;
        level = lvl;
        Debug.Log(mode + "\n" + level);
    }

    //Testing GUI Variables
    public Text qt;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;

    
    //Load Questions
    void LoadQuestion()
    {
        int RndQ;
               
        //Random Question Selection
        RndQ = Random.Range(0, RemainingQuestions.Count);
        //Debug.Log(RemainingQuestions[RndQ].question + RemainingQuestions[RndQ].answer);//Debugging
        quest = RemainingQuestions[RndQ].question;
        qt.text = quest;
        crrans = RemainingQuestions[RndQ].answer;

        //Removing Selected Question
        RemainingQuestions.RemoveAt(RndQ);
        
        
    }

    int[] Rnd;
    void LoadAnswers()
    {
        int temp = Random.Range(0, qd.Length);
        Rnd = new int[3];
        //Debug.Log(crrans);
        for (int i = 0; i < 3; i++)
        {
            while (IsDup(temp, Rnd) || crrans.Equals(qd[temp].answer))
            {
                temp = Random.Range(0, qd.Length);
            }
            Rnd[i] = temp;
            //Debug.Log(qd[Rnd[i]].answer);
        }
    }

    //Check condition for Random Numbers
    bool IsDup(int a, int[] al)
    {
        foreach (int x in al)
        {
            if (a == x)
            {
                return true;
            }
        }
        return false;
    }

    //Display Answers
    void DisplayAnswers()
    {
        //Aranging answers in random sequence
        int RandomCA = Random.Range(0, 4);
        string[] RndmSqnce = new string[4];
        RndmSqnce[RandomCA] = crrans;
        int d = 0;
        for (int c = 0; c < 4; c++)
        {
            if (c != RandomCA)
            {
                RndmSqnce[c] = qd[Rnd[d++]].answer;
            }
        }

        //Putting answers in buttons
        b1.GetComponent<TextMesh>().text = RndmSqnce[0];
        b2.GetComponent<TextMesh>().text = RndmSqnce[1];
        b3.GetComponent<TextMesh>().text = RndmSqnce[2];
        b4.GetComponent<TextMesh>().text = RndmSqnce[3];
    }

    
    //Checking Answers
    public void AnswerCheck(string ans)
    {
        string answer = ans;
        if (answer.Equals(crrans))
        {
            ResultSceneManager.UpdateScore();
        }
        else
        {
            QuizData WA = new QuizData();
            WA.question = qt.text;
            WA.answer = crrans;
            ResultSceneManager.AddAnswer(WA);
        }
    }


    static int QuesAttempted = -1;
    
    //On ButtonClick or OnCollision
    public void OnNext()
    {
        QuesAttempted++;
        if(RemainingQuestions.Count == 0)
        {
            //EndGame
            OnEndGame();
        }
        else
        {
            //Check Answer and reload scene
            LoadQuestion();
            LoadAnswers();
            DisplayAnswers();
        }               
    }


    //Clear Game data while ending
    void ClearData()
    {
        flag = 0;
        QuesAttempted = -1;
    }

    //End Game from Any Question Funtionality
    public void OnEndGame()
    {
        //Set Questions Attempted
        ResultSceneManager.SetAttemptedQuestions(QuesAttempted, TotalQues);
        ClearData();
        SceneManager.LoadScene(2);
    }
    
    //Firing Button Functionality
    bool DisableFire = false;

    public GameObject bull;
    public Transform CrossHair;
    public GameObject FireButton;
    Color FB_Color;
    public void OnFire()
    {
        if (DisableFire == false)
        {
            FB_Color = FireButton.GetComponent<Image>().color;
            GameObject bullet = Instantiate(bull) as GameObject;
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            bullet.transform.rotation = Camera.main.transform.rotation;
            bullet.transform.position = CrossHair.position;
            rb.AddForce(Camera.main.transform.forward * 4000f);
            Destroy(bullet, 5);
            GetComponent<AudioSource>().Play();
            DisableFire = true;
            FireButton.GetComponent<Image>().color = Color.red;
            FireButton.GetComponentInChildren<Text>().text = "Reloading";
            FireButton.GetComponentInChildren<Text>().color = Color.yellow;
            Invoke("EnableFire", 2.0f);
        }
        
    }

    void EnableFire()
    {
        DisableFire = false;
        FireButton.GetComponent<Image>().color = FB_Color;
        FireButton.GetComponentInChildren<Text>().text = "FIRE";
        FireButton.GetComponentInChildren<Text>().color = Color.black;
    }
}
