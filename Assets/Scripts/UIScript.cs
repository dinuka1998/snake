using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    private string MIAN_MENU_SCEAN_NAME= "MainMenu";
    public void PlayAgain() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GoToMenu() {

         SceneManager.LoadScene(MIAN_MENU_SCEAN_NAME);

    }

}
