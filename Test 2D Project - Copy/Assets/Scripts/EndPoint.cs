using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour {

    public GameObject endPanel;
    private SaveController saveController;

    private void Start()
    {
        saveController = FindObjectOfType<SaveController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Time.timeScale = 0;
            endPanel.SetActive(true);
            saveController.SaveLevel();   // Разблокировка следующего уровня
        }
    }
}