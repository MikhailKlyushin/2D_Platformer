using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт востановления здоровья игрока,
/// крепится к объекту зелья востановления
/// </summary>

public class AddHeal : MonoBehaviour {

    public int addHeal = 1;         // Количество добавляемых жизней
    public CharacterHp playerHP;
    private bool addedLives = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("is HEal true");
            playerHP = collision.GetComponent<CharacterHp>();
            addedLives = playerHP.AddHp(addHeal);
        }
    }

    private void Update()
    {
        // Удаляем объект после выполнения
        if (addedLives)
        {
            Destroy(gameObject);
        }
    }
}
