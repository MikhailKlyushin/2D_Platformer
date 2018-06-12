using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;   // скорость движения камеры

    [SerializeField]
    private Transform player;   // положение игрока

    void Awake ()
    {
        if (!player)
        {
            player = FindObjectOfType<Player>().transform;
        }
	}

	void FixedUpdate ()
    {
        Vector3 cameraPosition = player.position;    
        cameraPosition.z = -2;                      // коректировка камеры по Z
        cameraPosition.y = cameraPosition.y + 0.5f; // коректировка камеры по Y
        transform.position = Vector3.Lerp(transform.position, cameraPosition, speed * Time.deltaTime);  // Движение камеры
	}
}
