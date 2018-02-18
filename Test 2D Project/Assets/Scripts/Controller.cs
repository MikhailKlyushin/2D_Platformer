//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float horizontalSpeed;
    float speedX;
    public float verticalImpulse;
    Rigidbody2D rb;
    
    //Загружаемые при старте скрипта
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //Двивение влево
    public void LeftButtonDown()
    {
        speedX = -horizontalSpeed;
    }
    //Двивение вправо
    public void RightButtonDown()
    {
        speedX = horizontalSpeed;
    }
    //Прыжок
    public void JumpButtonDown()
    {
        rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
    }
    //Остановка движения
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
