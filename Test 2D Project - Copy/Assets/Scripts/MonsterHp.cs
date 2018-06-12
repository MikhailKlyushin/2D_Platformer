using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт HP монстра
/// </summary>

public class MonsterHp : CharacterHp {

    public float startHp = 5f;  // Начальное значение здоровья

    private bool isLive = true;
    private float actualHp;     // Актуальное значение жизней

    void Start()
    {
        actualHp = startHp;
    }

    // Получение урона монстром
    public override void GetDamage(float damage)
    {
        actualHp -= damage;
        Debug.Log("Monster HP = " + actualHp);
    }

    // Жив ли монстер
    public override bool CharIsLive()
    {
        isLive = (actualHp > 0) ? true : false;
        return isLive;
    }

    // Востановление HP
    public override bool AddHp(int nextHp)
    {
        return true;
    }
}
