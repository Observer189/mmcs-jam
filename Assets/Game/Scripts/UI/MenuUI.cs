 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public SettingsUI settingsUI;
    public void ButtonStart()
    {
        SceneLoader.Instance.LoadScene("Loading","Forest");
        //SceneManager.LoadScene("Forest");
    }
    public void ButtonContinue()
    {
        print("Continue");
    }
    public void ButtonExit()
    {
        Application.Quit();
    }
    public void ButtonSettings()
    {
        settingsUI.Show();
    }
    public void ButtonCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
