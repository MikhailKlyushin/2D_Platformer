using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour {

    private bool isPause = false;
    public GameObject pausePanel;

	void Start () {

    }
	
	void FixedUpdate () {

		if ((Input.GetKeyDown(KeyCode.Escape)) && !isPause)
        {
            PauseOn();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape)) && isPause)
        {
            PauseOff();
        }

    }

    // Включение паузы
    public void PauseOn()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isPause = true;
    }

    // Выключение паузы
    public void PauseOff()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPause = false;
    }

    // Выход из уровня в главное меню
    public void ExitLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
