//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    //переменная для установки макс. скорости персонажа
    public float maxSpeed = 10f;
    //переменная для установки силы прыжка персонажа
    public float jumpForce = 5f;
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;
    //ссылка на компонент анимаций
    private Animator anim;
    

    Rigidbody2D rb;
    
    //загружаемые при старте скрипта
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //движение влево
    public void LeftButtonDown()
    {
        speedX = -horizontalSpeed;
    }
    //движение вправо
    public void RightButtonDown()
    {
        speedX = horizontalSpeed;
    }
    //прыжок
    public void JumpButtonDown()
    {
        rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
    }
    //остановка движения
    public void Stop()
    {
        speedX = 0;
    }

    //Загружаемые с фиксируемой частотой
    void FixedUpdate()
    {
        //Движение персонажа с использованием метода transform
        transform.Translate(speedX, 0, 0);
    }
}
