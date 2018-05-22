using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт основных настроек уровня,
/// крепится к кнопке уровня
/// </summary>

public class LevelSettings : MonoBehaviour
{
    public int numberLevel = 1;

    public LevelController levelController;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    // Передача параметров в стартер и запуск уровня
    public void SetLevelSettings()
    {
        levelController.numberLevel = numberLevel;
        levelController.StartingLevel();
    }
}
