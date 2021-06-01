using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneUIScript : MonoBehaviour {



    // Update is called once per frame
    public GameObject QuitConfirm;
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameObject.Find("ConfirmQuit(Clone)") != null)
            {

            }
            else
            {
                OnExit();
            }
        }
	}

    //OnPlayagain button press
    public void OnPlayAgain()
    {
        GameObject.Find("ResultManager").GetComponentInChildren<ResultSceneManager>().ClearResults();//Clear Results List
        SceneManager.LoadScene(0); //Go back to main screen
    }

    public void OnExit()
    {
        Instantiate(QuitConfirm);
    }
}
