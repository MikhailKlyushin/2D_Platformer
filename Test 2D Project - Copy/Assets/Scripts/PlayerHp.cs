using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт отвечающий на HP игрока
/// </summary>

public class PlayerHp : CharacterHp {

    public float startHp = 5f;  // Начальное значение здоровья

    private bool isLive = true;
    private float actualHp;     // Актуальное значение жизней

    // Передаем кол-во жизней в др. скрипты
    public float Lives
    {
        get { return actualHp; }
        set { actualHp = value; }
    }

    void Start()
    {
        actualHp = startHp;
    }

    // Получение урона игроком
    public override void GetDamage(float damage)
    {
        actualHp -= damage;
        Debug.Log("actualHP = " + actualHp);
    }

    // Жив ли игрок
    public override bool CharIsLive()
    {
        isLive = (actualHp > 0) ? true : false;
        return isLive;
    }

    // Востановление HP
    public override bool AddHp(int nextHp)
    {
        int sumHp = nextHp + (int)Lives;    // Сумма HP после востановления

        // Выполнеям если HP меньше чем при старте
        if (Lives < startHp)
        {
            if (sumHp > startHp)
            {
                Lives = startHp;
            }
            else
            {
                Lives = sumHp;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
