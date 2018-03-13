using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //Бибилиотека для взаимодействия со сценами

public class MainMenuScript : MonoBehaviour {

    //Кнопка "Начать игру"
    public void OnClickStart()
    {        
        SceneManager.LoadScene(1);
    }

    //Кнопка "Выход"
    public void OnClickExit()
    {
        Application.Quit();
    }
}
