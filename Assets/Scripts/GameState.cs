using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    //TODO: STATE MACHINE????
    public GameObject startMenuUI;
    public GameObject restartMenuUI;

    private void Awake()
    {
        PreStartGame();
    }

    /// <summary>Start's the game</summary>
    public void StartGame()
    {
        startMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>Sets the game in state before start.</summary>
    public void PreStartGame()
    {
        startMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>Sets the game in state after players hit.</summary>
    public void Defeat()
    {
        restartMenuUI.SetActive(true);

        Time.timeScale = 0.5f;
    }

    /// <summary>Restart's the game</summary>
    public void Restart()
    {
        restartMenuUI.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
