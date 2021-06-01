using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasScript : MonoBehaviour {


    // Update is called once per frame
    public GameObject QuitConfirmMenu;
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                ResumeGame();
            }
            else
            {
                if (GameObject.Find("ConfirmQuit(Clone)") != null)
                {
                    
                }
                else
                {
                    Instantiate(QuitConfirmMenu);
                }
            }
        }
	}
    
    public static bool IsGamePaused = false;
    public GameObject Pm; //PauseMenu Game Object
    //OnPauseButtonPress
    public void PauseGame()
    {
        if (!IsGamePaused)
        {
            IsGamePaused = true;
            Instantiate(Pm);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        if (IsGamePaused)
        {
            IsGamePaused = false;
            Destroy(GameObject.Find(name: "PauseMenu(Clone)"));
            Time.timeScale = 1f;
        }
    }
}
