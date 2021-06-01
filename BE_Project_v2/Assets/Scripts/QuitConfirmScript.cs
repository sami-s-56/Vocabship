using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitConfirmScript : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnNoClick();
        }
	}

    public void OnYesClick()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }

    GameObject sm;
    public void OnNoClick()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        if(CurrentScene.name == "StartUI")
        {
            sm = GameObject.Find("SceneMngr");
            sm.GetComponent<StartManager>().enabled = true;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Wont go for Start Manager");
            Destroy(gameObject);
        }
    }
}
