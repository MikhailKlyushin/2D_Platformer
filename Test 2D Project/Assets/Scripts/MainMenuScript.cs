using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //Бибилиотека для взаимодействия со сценами

public class MainMenuScript : MonoBehaviour {

    public GameObject levelPanel;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

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
