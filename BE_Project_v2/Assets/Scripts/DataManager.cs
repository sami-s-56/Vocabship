using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    public QuizData[] qd;

    public void SetData(string mode, string level)
    {
        qd = new QuizData[10];
        for (int c = 0; c < 10; c++)                                                  //Initialize Array
        {
            qd[c] = new QuizData();
        }

        switch (mode)
        {
            case "Synonyms":                                                          //Synonyms
                switch (level)
                {
                    case "Easy":                                                        //EasySyns
                        //Temporary Data
                        qd[0].question = "Synonym 1 1";
                        qd[0].answer = "Answer_Synonym 1";
                        qd[1].question = "Synonym 1 2";
                        qd[1].answer = "Answer_Synonym 2";
                        qd[2].question = "Synonym 1 3";
                        qd[2].answer = "Answer_Synonym 3";
                        qd[3].question = "Synonym 1 4";
                        qd[3].answer = "Answer_Synonym 4";
                        qd[4].question = "Synonym 1 5";
                        qd[4].answer = "Answer_Synonym 5";
                        qd[5].question = "Synonym 1 6";
                        qd[5].answer = "Answer_Synonym 6";
                        qd[6].question = "Synonym 1 7";
                        qd[6].answer = "Answer_Synonym 7";
                        qd[7].question = "Synonym 1 8";
                        qd[7].answer = "Answer_Synonym 8";
                        qd[8].question = "Synonym 1 9";
                        qd[8].answer = "Answer_Synonym 9";
                        qd[9].question = "Synonym 1 10";
                        qd[9].answer = "Answer_Synonym 10";
                        break;
                    case "Medium":                                                     //MedSyns
                        qd[0].question = "Synonym 2 1";
                        qd[0].answer = "Answer_Synonym 1";
                        qd[1].question = "Synonym 2 2";
                        qd[1].answer = "Answer_Synonym 2";
                        qd[2].question = "Synonym 2 3";
                        qd[2].answer = "Answer_Synonym 3";
                        qd[3].question = "Synonym 2 4";
                        qd[3].answer = "Answer_Synonym 4";
                        qd[4].question = "Synonym 2 5";
                        qd[4].answer = "Answer_Synonym 5";
                        qd[5].question = "Synonym 2 6";
                        qd[5].answer = "Answer_Synonym 6";
                        qd[6].question = "Synonym 2 7";
                        qd[6].answer = "Answer_Synonym 7";
                        qd[7].question = "Synonym 2 8";
                        qd[7].answer = "Answer_Synonym 8";
                        qd[8].question = "Synonym 2 9";
                        qd[8].answer = "Answer_Synonym 9";
                        qd[9].question = "Synonym 2 10";
                        qd[9].answer = "Answer_Synonym 10";
                        break;
                    case "Hard":                                                            //Hard Syns
                        qd[0].question = "Synonym 3 1";
                        qd[0].answer = "Answer_Synonym 1";
                        qd[1].question = "Synonym 3 2";
                        qd[1].answer = "Answer_Synonym 2";
                        qd[2].question = "Synonym 3 3";
                        qd[2].answer = "Answer_Synonym 3";
                        qd[3].question = "Synonym 3 4";
                        qd[3].answer = "Answer_Synonym 4";
                        qd[4].question = "Synonym 3 5";
                        qd[4].answer = "Answer_Synonym 5";
                        qd[5].question = "Synonym 3 6";
                        qd[5].answer = "Answer_Synonym 6";
                        qd[6].question = "Synonym 3 7";
                        qd[6].answer = "Answer_Synonym 7";
                        qd[7].question = "Synonym 3 8";
                        qd[7].answer = "Answer_Synonym 8";
                        qd[8].question = "Synonym 3 9";
                        qd[8].answer = "Answer_Synonym 9";
                        qd[9].question = "Synonym 3 10";
                        qd[9].answer = "Answer_Synonym 10";
                        break;
                }
                break;
            case "Antonyms":                                                          //Antonyms
                switch (level)
                {
                    case "Easy":
                        break;
                    case "Medium":
                        break;
                    case "Hard":
                        break;
                }
                break;
            //Add Rest of cases here
        }
    }

    public QuizData[] GetData()
    {
        return qd;
    }
}
