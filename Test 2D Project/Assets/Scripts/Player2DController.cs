//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour
{

    //переменная для установки макс. скорости персонажа
    public float maxSpeed = 10f;
    //переменная для установки силы прыжка персонажа
    public float jumpForce = 5f;
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;
    //ссылка на компонент анимаций
    private Animator anim;
    //переменная запоминающая направление движения
    float speedX;
    public float backPosition = 1.2f;


    Rigidbody2D rb;
    
    //загружаемые при старте скрипта
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //движение влево
    public void LeftButtonDown()
    {
        speedX = -maxSpeed;
    }
    //движение вправо
    public void RightButtonDown()
    {
        speedX = maxSpeed;
    }
    //прыжок
    public void JumpButtonDown()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
    //остановка движения
    public void Stop()
    {
        speedX = 0;
    }

    //Организация двидения средствами transform с фиксируемой частотой
    void FixedUpdate()
    {
        //Движение персонажа с использованием метода transform
        transform.Translate(speedX / 100f, 0, 0);

        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        if (speedX > 0 && !isFacingRight)
        {
            //отражаем персонажа вправо
            Flip();
            transform.Translate(backPosition, 0, 0);
        }
        //обратная ситуация. отражаем персонажа влево
        else if (speedX < 0 && isFacingRight)
        {
            Flip();
            transform.Translate(-backPosition, 0, 0);
        }
            
    }

    //Метод для смены направления движения персонажа и его зеркального отражения
    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
        

    }


}
