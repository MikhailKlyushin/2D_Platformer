using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт кнопок гланого меню,
/// крепится к камере меню
/// </summary>

public class MainMenuScript : MonoBehaviour {

    public GameObject levelPanel;
    public GameObject skillsPanel;

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

    //Кнопка "Навыки игрока"
    public void OpenSkills()
    {
        skillsPanel.SetActive(true);
    }

    public void CloseSkills()
    {
        skillsPanel.SetActive(false);
    }

    //Кнопка "Выход"
    public void OnClickExit()
    {
        Application.Quit();
    }

}
