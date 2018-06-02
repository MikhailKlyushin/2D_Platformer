using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт смерти персонажей при падении в обрыв,
/// крепится к блоку обрыва
/// </summary>

public class DeadBreakage : MonoBehaviour {

    private GameObject player;
    private PlayerHp playerHp;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHp = player.GetComponent<PlayerHp>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHp.Lives = 0;
            Invoke("SetTimeNull", 0.8f);
        }
        else if (collision.tag == "Monster")
        {
            GameObject monster = collision.gameObject;
            Destroy(monster, 1);
        }
    }

    private void SetTimeNull()
    {
        Time.timeScale = 0;
    }
}
