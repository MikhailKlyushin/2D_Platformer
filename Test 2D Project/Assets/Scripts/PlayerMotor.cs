using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт включает основные методы действий игрового персонажа
/// </summary>

public class PlayerMotor : CharactersMotor {

    public virtual void Attack() { }        // Атака
    public virtual void Dead() { }          // Действия при смерти
    public override void GetDamage(float damage)    // Получение урона
    { }
    public override void SetDamage()    // Нанесение урона
    { }

    public override void Run(Transform thisTransform, float speedX) // Движение
    {
        //throw new System.NotImplementedException();
        thisTransform.Translate(speedX / 100f, 0, 0);   //Движение персонажа с использованием метода transform
    }

    public override void Jump(Rigidbody2D thisRigidbody, float jumpForce, bool isGrounded)  // Прыжок
    {
        if(isGrounded == true)
        {
            thisRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    public override float Stop()    // Остановка
    {
        return 0;
    }    
    
    public void Flip(Transform thisTransform)   // Разворот модели персонажа в обратную сторону
    {
        Vector3 theScale = thisTransform.localScale;    // Получаем размеры персонажа        
        theScale.x *= -1;                               // Зеркально отражаем персонажа по оси Х        
        thisTransform.localScale = theScale;            // Задаем новый размер персонажа, равный старому, но зеркально отраженный
    }

    public void BackPosition(Transform thisTransform, float backValue)
    {
        thisTransform.Translate(backValue, 0, 0);
    }

    public bool ModelTurn(Transform thisTransform, bool isFacingRight, float speedX, float backValue)    // Разворот модели в зависимости от положения
    {
        if (speedX > 0 && !isFacingRight)   // отражаем персонажа вправо
        {            
            Flip(thisTransform);
            isFacingRight = !isFacingRight;
            BackPosition(thisTransform, backValue);
        }            
        else if (speedX < 0 && isFacingRight)   // отражаем персонажа влево
        {
            Flip(thisTransform);
            isFacingRight = !isFacingRight;
            BackPosition(thisTransform, -backValue);
        }
        return isFacingRight;        
    }

    // Эффект при получении урона
    public void DamageEffect(SpriteRenderer thisSpriteRender, Rigidbody2D thisRigidbody)
    {
        thisSpriteRender.color = Color.red;     // Эффект повреждения
        thisRigidbody.AddForce(transform.up * 30f, ForceMode2D.Impulse);
    }

    // Отключение эффекта
    public void OffDamageEffect(SpriteRenderer thisSpriteRender)
    {
        thisSpriteRender.color = Color.white;     // Эффект повреждения        
    }
}
