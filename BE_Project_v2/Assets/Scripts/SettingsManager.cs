using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBack();
        }
    }

    public GameObject MainScreen;
    public GameObject sm;
    public void OnBack()
    {
        MainScreen.SetActive(true);
        sm.GetComponent<StartManager>().enabled = true;
        gameObject.SetActive(false);
    }
}
