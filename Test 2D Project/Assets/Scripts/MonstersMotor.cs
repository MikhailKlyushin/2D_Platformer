using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт включает основные методы действий монстра
/// </summary>

public class MonstersMotor : CharactersMotor {

    public virtual void Attack() { }        // Атака
    public virtual void TakeDamage() { }    // Получение урона
    public virtual void Dead() { }          // Действия при смерти
    public override void GetDamage(float damage)    // Получение урона
    { }
    public override void SetDamage()                // Нанесение урона
    { }

    // Движение
    public override void Run(Transform thisTransform, float speedX) 
    {
        //throw new System.NotImplementedException();
        thisTransform.Translate(speedX / 100f, 0, 0);   //Движение персонажа с использованием метода transform
    }
    
    // Прыжок
    public override void Jump(Rigidbody2D thisRigidbody, float jumpForce, bool isGrounded)  
    {
        if (isGrounded == true)
        {
            thisRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    
    // Остановка
    public override float Stop()    
    {
        return 0;
    }
    
    // Разворот модели персонажа в обратную сторону
    public void Flip(Transform thisTransform)   
    {
        Vector3 theScale = thisTransform.localScale;    // Получаем размеры персонажа        
        theScale.x *= -1;                               // Зеркально отражаем персонажа по оси Х        
        thisTransform.localScale = theScale;            // Задаем новый размер персонажа, равный старому, но зеркально отраженный
    }

    // Корректировка полложения персонажа после разворота
    public void BackPosition(Transform thisTransform, float backValue)
    {
        thisTransform.Translate(backValue, 0, 0);
    }

    // Разворот модели в зависимости от задней области
    public bool ModelTurn(Transform thisTransform, bool isFacingRight, bool backColision, float backValue)    
    {
        if (backColision && !isFacingRight)   // отражаем персонажа вправо
        {
            Flip(thisTransform);
            isFacingRight = !isFacingRight;
            BackPosition(thisTransform, backValue);
        }
        else if (backColision && isFacingRight)   // отражаем персонажа влево
        {
            Flip(thisTransform);
            isFacingRight = !isFacingRight;
            BackPosition(thisTransform, -backValue);
        }

        return isFacingRight;
    }
    
    // Метод анализирующий приближение игрока спереди
    public float FrontCollisionControl(float playerPositionX, float monsterPositionX, bool isFacingRight, float speedX, float maxSpeed)
    {
        if ((playerPositionX < monsterPositionX) && !isFacingRight)
        {
            speedX = -maxSpeed;
        }
        else if ((playerPositionX > monsterPositionX) && isFacingRight)
        {
            speedX = maxSpeed;
        }

        return speedX;
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
