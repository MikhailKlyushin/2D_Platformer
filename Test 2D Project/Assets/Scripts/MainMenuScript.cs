using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт кнопок гланого меню
/// </summary>

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
        levelPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        levelPanel.SetActive(false);
    }

    //Кнопка "Выход"
    public void OnClickExit()
    {
        Application.Quit();
    }

}
