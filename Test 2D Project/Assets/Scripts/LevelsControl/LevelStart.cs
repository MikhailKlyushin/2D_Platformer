using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //Бибилиотека для взаимодействия со сценами

/// <summary>
/// Скрипт запуска уровня,
/// крепится к пустому объекту на сцене
/// </summary>

public class LevelStart : MonoBehaviour {

    public int numberLevel = 1;
    public int lenghtLevel = 60;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void FixedUpdate()
    {
        Debug.Log("Active");
    }

    // Запуск игровой сцены
    public void StartingLevel()
    {
        SceneManager.LoadScene(2);
    }
}
