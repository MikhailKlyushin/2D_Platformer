using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public float maxSpeed = 10f;    //переменная для установки макс. скорости персонажа   
    public float jumpForce = 5f;    //переменная для установки силы прыжка персонажа  
    public float backPosition = 1.2f;   //переменная компенсирования смещения игрока при смене направления движения
    public bool isFacingRight = true;   //переменная для определения направления персонажа вправо/влево
    private bool isGrounded;
    public bool AttackAnimation;
    float speedX;   //переменная запоминающая направление движения

    //private Rigidbody2D rb;
    private Animator animator;  //ссылка на компонент анимаций

    public GameObject player;
    public GameObject enemy;
    public GameObject frontView;
    public GameObject backView;

    private float frontDistance;
    private float onDistance;

    public float timer;
    public bool yes;
    public float newtimer;

    bool BackColision;

    public float playerPositionX;
    public float enemyPositionX;

    void Start()
    {
        animator = GetComponent<Animator>();
        frontDistance = float.Parse(frontView.transform.localScale.x.ToString());
    }

    void Update()
    {
        BackColision = backView.GetComponent<FieldView>().OnColisionTrue;
        onDistance = Vector2.Distance(transform.position, player.transform.position);
        playerPositionX = player.transform.position.x;
        enemyPositionX = enemy.transform.position.x;
        FrontCollisionControl();
        BackCollisionControl();
        Attack();
    }

    void FixedUpdate()
    {
        if (onDistance < frontDistance)
        {
            transform.Translate(speedX / 100f, 0, 0);   //Движение персонажа с использованием метода transform
            animator.SetFloat("Speed", Mathf.Abs(speedX * 10));  //Вкл. анимацию бега
        }
        else
        {
            speedX = 0;
            animator.SetFloat("Speed", 0);  //Выкл. анимацию бега
        }

        Debug.Log(onDistance);
    }

    //Метод анализирующий приближение игрока спереди
    public void FrontCollisionControl()
    {        
        if ((playerPositionX < enemyPositionX) && !isFacingRight)
        {
            speedX = -maxSpeed;
        }
        else
        if ((playerPositionX > enemyPositionX) && isFacingRight)
        {
            speedX = maxSpeed;
        }        
    }

    //Метод анализирующий приближение игрока сзади
    public void BackCollisionControl()
    {
        if (BackColision)
        {
            switch (isFacingRight)
            {
                case true:
                    Flip();
                    speedX = -maxSpeed;
                    break;
                case false:
                    Flip();
                    speedX = maxSpeed;
                    break;
            }
        }
    }

    public void Attack()
    {
        if (onDistance < 0.63f)
        {
            speedX = 0;
            animator.SetFloat("Speed", 0);  //Выкл. анимацию бега
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
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

}
