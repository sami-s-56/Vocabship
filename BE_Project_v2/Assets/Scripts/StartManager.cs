using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

    public Text mode;
    public Text level;
    public Text errorText;

    private string[] modes = { "Synonyms", "Antonyms" };
    private string[] levels = { "Easy", "Medium", "Hard" };

    int lvlCount = -1;
    int modeCount = -1;

    private void Start()
    {
        errorText.text = errorString;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitButton();
        }
    }

    public void NextMode()
    {
        if (modeCount == modes.Length-1)
        {
            modeCount = -1;
        }
        mode.text = modes[++modeCount];
        Debug.Log(modes.Length.ToString());
    }

    public void PrevMode()
    {
        if (modeCount == 0 || modeCount == -1)
        {
            modeCount = modes.Length;
        }
        mode.text = modes[--modeCount];
        Debug.Log(modeCount.ToString());
    }

    public void NextLvl()
    {
        if (lvlCount == levels.Length-1)
        {
            lvlCount = -1;
        }
        level.text = levels[++lvlCount];
    }

    public void PrevLvl()
    {
        if (lvlCount == 0 || lvlCount == -1)
        {
            lvlCount = levels.Length;
        }
        level.text = levels[--lvlCount];
    }

    public void StartGame()
    {
        if(mode.text == "MODE" || level.text == "LEVEL")
        {
            errorText.text = "Please Select Proper Mode and Level";
        }
        else
        {
            ManagerScript.SetMdLvl(mode.text, level.text);
            SceneManager.LoadScene(1);
            //errorText.text = mode.text + "\t" + level.text + "\tNext Scene Loaded";
        }
    }

    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public void SettingMenu()
    {
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
        gameObject.GetComponent<StartManager>().enabled = false;
    }

    public GameObject ExitConfirm;
    public void ExitButton()
    {
        Instantiate(ExitConfirm);
        ExitConfirm.SetActive(true);
        gameObject.GetComponent<StartManager>().enabled = false;
       
    }

    static string errorString = null;
    public static void NoDataFound()
    {
        errorString = "No Data Found for this mode and level";
    }
   
}
