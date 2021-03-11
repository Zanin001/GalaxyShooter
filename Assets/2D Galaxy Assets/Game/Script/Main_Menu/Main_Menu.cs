using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void LoadSinglePlayerGame()
    {
        SceneManager.LoadScene("Single_Player");
        Debug.Log("Single Player Game Loading...");
    }

    public void LoadMultiplayerGame()
    {
        SceneManager.LoadScene("Co-Op");
        Debug.Log("Multiplayer Game Loading...");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void LoadMPControls()
    {
        SceneManager.LoadScene("Controls_MP");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
