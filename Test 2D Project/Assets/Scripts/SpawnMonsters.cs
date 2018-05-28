using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : MonoBehaviour {

    public GameObject enemy;                // Префаб монстра
    private Transform spawnPoints;          // Позиция спавна

    void Start()
    {
        spawnPoints = GetComponent<Transform>();
        Spawn();   // Запуска спавнера
    }


    private void Spawn()
    {
        int qtyEnemy = Random.Range(0, 3);  //  кол-во монстров на 1 точке
        
        for (int i = 0; i <= qtyEnemy; i++)
        {
            AddToScene();
        }
    }

    private void AddToScene()
    {
        Instantiate(enemy, spawnPoints.position, spawnPoints.rotation); // Добавляем монстра в сцену
        Debug.Log("Time.time = " + Time.time);
    }
}