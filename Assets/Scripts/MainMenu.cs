using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string PLAY_GAME_SCEAN_NAME= "GamePlay";

    public void StartGame(){

        SceneManager.LoadScene(PLAY_GAME_SCEAN_NAME);

    }

    public void Exit(){

        Application.Quit();
    }
}
