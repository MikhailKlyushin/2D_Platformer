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

    public static LevelStart Instance;

    void Awake()
    {
        this.InstantiateController();
    }

    private void InstantiateController()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(this.gameObject);
        }
    }

    // Запуск игровой сцены
    public void StartingLevel()
    {
        SceneManager.LoadScene(2);
    }
}
