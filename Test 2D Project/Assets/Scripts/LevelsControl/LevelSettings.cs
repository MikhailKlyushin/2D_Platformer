using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт основных настроек уровня,
/// крепится к кнопке уровня
/// </summary>

public class LevelSettings : MonoBehaviour
{
    public float numberLevel = 1;
    public float lenghtLevel = 60;
    public float startLenghtLevel = 60;   // Стартовое значение уровня
    private float lenghtCoefficient = 0.2f;

    public LevelStart levelStart;

    private void Start()
    {
        levelStart = FindObjectOfType<LevelStart>();
    }

    public void RefreshLenght()
    {    
        lenghtLevel = Mathf.Floor((numberLevel + 4) * startLenghtLevel * lenghtCoefficient);
    }

    // Передача параметров в стартер и запуск уровня
    public void SetLevelSettings()
    {
        levelStart.numberLevel = (int)numberLevel;
        levelStart.lenghtLevel = (int)lenghtLevel;
        levelStart.StartingLevel();
    }
}
