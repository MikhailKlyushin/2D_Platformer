using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour {

    public GameObject player;               // Префаб игрока
    private Transform startPoints;          // Позиция спавна
    private Transform playerPosition;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerPosition = player.GetComponent<Transform>();
        startPoints = GetComponent<Transform>();
        Spawn();   // Запуска спавнера
    }


    private void Spawn()
    {
        playerPosition.position = startPoints.position;
    }
}
