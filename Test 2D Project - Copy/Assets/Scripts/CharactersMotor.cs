using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Главный скрипт определяющий основные действия для персонажей игры
/// </summary>

public abstract class CharactersMotor : MonoBehaviour {

    public abstract void Run(Transform transform, float speedX);                            // Движение влево/вправо
    public abstract void Jump(Rigidbody2D rigidbody, float jumpForce, bool isGrounded);     // Прыжок
    public abstract float Stop();                                                           // Остановка движений
    public abstract void GetDamage(float damage);                                           // Получение урона
    public abstract void SetDamage();                                                       // Нанесение урона
}
