using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //Бибилиотека для взаимодействия со сценами

public class MainMenuScript : MonoBehaviour {

    public GameObject levelPanel;

    //Кнопка "Начать игру"
    public void OnClickStart()
    {
        //SceneManager.LoadScene(1);
        levelPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        //SceneManager.LoadScene(1);
        levelPanel.SetActive(false);
    }

    //Кнопка "Выход"
    public void OnClickExit()
    {
        Application.Quit();
    }
}
