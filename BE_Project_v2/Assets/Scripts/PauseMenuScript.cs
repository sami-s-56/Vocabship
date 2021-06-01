using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

	public void OnEnd()
    {
        //Manage Results and Go to ResultScreen
        GameObject.Find("GameManager").GetComponent<ManagerScript>().OnEndGame();
    }

    public GameObject ConfirmExit;
    public void OnExit()
    {
        Instantiate(ConfirmExit);
    }

    public void OnResume()
    {
        GameObject.Find("Canvas").GetComponentInChildren<GameCanvasScript>().ResumeGame();
    }
    
}
