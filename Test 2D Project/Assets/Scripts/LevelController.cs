using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public int numberLevel = 1;                 // Номер уровня
    public float lenghtLevel = 0;              // Длины уровня
    public float startLenghtLevel = 60;         // Стартовое значение уровня
    private float lenghtCoefficient = 0.2f;

    public static LevelController Instance;

    // Вызывается когда экземпляр скрипта будет загружен
    void Awake()
    {
        this.InstantiateController();
        lenghtLevel = startLenghtLevel;
    }

    // Определяем есть ли дубликаты объекта
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

    // Расчет длины уровня    
    public void RefreshLenght()
    {
        lenghtLevel = Mathf.Floor((numberLevel + 4) * startLenghtLevel * lenghtCoefficient);
    }

    // расчет длины уровня и запуск игровой сцены
    public void StartingLevel()
    {
        RefreshLenght();
        SceneManager.LoadScene(2);
    }
}
