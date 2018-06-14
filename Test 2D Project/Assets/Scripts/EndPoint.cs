using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour {

    public GameObject endPanel;
    private SaveController saveController;
    private PlayerScopes playerScopes;

    private void Start()
    {
        saveController = FindObjectOfType<SaveController>();
        playerScopes = FindObjectOfType<PlayerScopes>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Time.timeScale = 0;
            endPanel.SetActive(true);
            saveController.sv.level++;   // Разблокировка следующего уровня
            saveController.sv.scopes += playerScopes.MyScopes;
            Debug.Log("playerScopes.MyScopes = " + playerScopes.MyScopes);
        }
    }
}