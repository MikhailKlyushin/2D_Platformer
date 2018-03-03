//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AnimationComtroller))] //подключить скрипт PlayMode

public class Player2DController : MonoBehaviour
{

    
    public float maxSpeed = 10f;    //переменная для установки макс. скорости персонажа   
    public float jumpForce = 5f;    //переменная для установки силы прыжка персонажа  
    public float backPosition = 1.2f;   //переменная компенсирования смещения игрока при смене направления движения
    public bool isFacingRight = true;   //переменная для определения направления персонажа вправо/влево
    private bool isGrounded;
    public bool AttackAnimation;
    float speedX;   //переменная запоминающая направление движения

    private Rigidbody2D rb;    
    private Animator animator;  //ссылка на компонент анимаций
    //private AnimationComtroller AnimContr;

    //загружаемые при старте скрипта
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //AnimContr = GetComponent<AnimationComtroller>();
    }

    //движение влево
    public void LeftButtonDown()
    {
        speedX = -maxSpeed;        
        animator.SetFloat("Speed", Mathf.Abs(speedX));  //Вкл. анимацию бега
    }

    //движение вправо
    public void RightButtonDown()
    {
        speedX = maxSpeed;        
        animator.SetFloat("Speed", Mathf.Abs(speedX));//Вкл. анимацию бега
    }

    //прыжок
    public void JumpButtonDown()
    {
        if (isGrounded == true)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
        }
    }

    //остановка движения
    public void Stop()
    {
        speedX = 0;
        //Выкл. анимацию бега
        animator.SetFloat("Speed", Mathf.Abs(speedX));
    }

    //удар
    public void AttackButtonDown()
    {
        if (AttackAnimation == false)
        {
            speedX = 0;
            animator.SetFloat("Speed", 0);
            animator.SetBool("Attack", true);
        }
    }

    //завершение удара
    public void AttackEnd()
    {
        animator.SetBool("Attack", false);
    }

    //Организация двидения средствами transform с фиксируемой частотой
    void FixedUpdate()
    {        
        transform.Translate(speedX / 100f, 0, 0);   //Движение персонажа с использованием метода transform

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
        isFacingRight = !isFacingRight; //меняем направление движения персонажа        
        Vector3 theScale = transform.localScale;    //получаем размеры персонажа        
        theScale.x *= -1;   //зеркально отражаем персонажа по оси Х        
        transform.localScale = theScale;    //задаем новый размер персонажа, равный старому, но зеркально отраженный       
    }

    //Проверяем находится ли игрок на земле, если да то разрешаем прыжок, и выкл. анимацию прыжка
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("Jump", false);            
        }

    }

    //Если игрок перестает касаться земли то запрещаем прыжок
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }       

    public void AttackAniationTrue()
    {
        AttackAnimation = true;
    }

    public void AttackAniationFalse()
    {
        AttackAnimation = false;
    }

}