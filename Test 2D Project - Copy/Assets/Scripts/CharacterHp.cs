using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Главный скрипт HP персонажей игры
/// </summary>

public abstract class CharacterHp : MonoBehaviour {

    public abstract void GetDamage(float damage);   // Получение урона
    public abstract bool CharIsLive();              // Жив ли персонаж
    public abstract bool AddHp(int nextHp);         // Востановление жизней
}
