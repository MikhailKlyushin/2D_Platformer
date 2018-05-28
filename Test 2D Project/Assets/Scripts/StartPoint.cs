using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour {

    public GameObject player;               // Префаб игрока
    private Transform startPoints;          // Позиция спавна

    void Start()
    {
        startPoints = GetComponent<Transform>();
        Spawn();   // Запуска спавнера
    }


    private void Spawn()
    {
        Instantiate(player, startPoints.position, startPoints.rotation); // Добавляем игрока в сцену
        Debug.Log("Time.time = " + Time.time);
    }
}
