using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Главный скрипт игрока, овечает за действия и управление
/// </summary> 

public class Player : PlayerMotor {

    public float maxSpeed = 10f;        // макс. скорость персонажа   
    public float jumpForce = 5f;        // сила прыжка персонажа  
    public float backValue = 1.2f;      // компенсирование смещения игрока при смене направления движения
    public bool isFacingRight = true;   // направление персонажа вправо/влево
    public float attackDamage = 1;      // урон при атаке
    public float timeEffect = 0.3f;     // время эффекта повреждения
    private bool isGrounded;            // находится ли персонаж на земле
    private bool AttackAnimation;
    private float speedX;               // переменная запоминающая направление движения

    private Rigidbody2D thisRigidbody;
    public Transform thisTransform;
    private Animator thisAnimator;
    private SpriteRenderer thisSpriteRender;

    public CharacterHp playerHp;            // ссылка на компонент Hp игрока
    public bool playerIsLive = true;        // показывает жив ли игрок
    public CharactersMotor charactersMotor; // ссылка на компонент действий игрока
    private AttackArea attackArea;          // область атаки игрока

    private bool canAttack = false;

    private SaveController saveController;  // Сохраненные параметры

    void Start()
    {
        thisSpriteRender = GetComponent<SpriteRenderer>();
        thisRigidbody = GetComponent<Rigidbody2D>();
        thisTransform = transform;
        thisAnimator = GetComponent<Animator>();
        playerHp = GetComponent<CharacterHp>();
        attackArea = FindObjectOfType<AttackArea>();
        saveController = FindObjectOfType<SaveController>();

        maxSpeed = saveController.sv.speedPlayer;
        jumpForce = saveController.sv.jumpForcePlayer;
        attackDamage = saveController.sv.attackDamagePlayer;
    }

    void Update()
    {
        Dead();
    }

    void FixedUpdate()
    {
        Run(thisTransform, speedX);
        playerIsLive = playerHp.CharIsLive();
        thisSpriteRender.color = Color.red;
        canAttack = attackArea.OnColisionTrue;
        charactersMotor = attackArea.childrelCharMotor; // получаем компонент монстра если он находится а зоне атаки
    }
        
    public void LeftButtonDown()    // движение влево
    {
        speedX = -maxSpeed;
        isFacingRight = ModelTurn(thisTransform, isFacingRight, speedX, backValue);
        thisAnimator.SetFloat("Speed", Mathf.Abs(speedX));  //Вкл. анимацию бега
    }
    
    public void RightButtonDown()   // движение вправо
    {
        speedX = maxSpeed;
        isFacingRight = ModelTurn(thisTransform, isFacingRight, speedX, backValue);
        thisAnimator.SetFloat("Speed", Mathf.Abs(speedX));//Вкл. анимацию бега
    }

    
    public void JumpButtonDown()    // прыжок
    {
        if (isGrounded == true)
        {
            thisRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            thisAnimator.SetBool("Jump", true);
        }
    }

    public void StopPlayer()
    {
        speedX = Stop();        
        thisAnimator.SetFloat("Speed", Mathf.Abs(speedX));  // Выкл. анимацию бега
    }
    
    private void OnCollisionStay2D(Collision2D collision)   // Проверяем находится ли игрок на земле, если да, то разрешаем прыжок и выкл. анимацию прыжка
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            thisAnimator.SetBool("Jump", false);
        }

    }
    
    private void OnCollisionExit2D(Collision2D collision)   // Если игрок перестает касаться земли то запрещаем прыжок
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public override void Attack()
    {
        speedX = Stop();
        thisAnimator.SetFloat("Speed", 0);
        thisAnimator.SetBool("Attack", true);
        Invoke("AnimationAttackFalse", 0.45f);  // Выкл. анимации удара
    }

    // Выключение анимации удара, вызов из др. метода
    public void AnimationAttackFalse()
    {
        thisAnimator.SetBool("Attack", false);
    }

    // Нанесение урона монстру, вызывается из анимации
    public override void SetDamage()
    {
        if (canAttack) // если враг в зоне атаки
        {
            charactersMotor.GetDamage(attackDamage);
        }
    }

    // Получение урона
    public override void GetDamage(float damage)
    {
        if (playerIsLive)
        {
            playerHp.GetDamage(damage);
            DamageEffect(thisSpriteRender, thisRigidbody);     // Эффект получения урона
            Invoke("DamageOff", timeEffect);    // Выкл. эффекта

        }
    }

    // Вызываем выключение эффекта, 
    private void DamageOff()
    {
        OffDamageEffect(thisSpriteRender);
    }

    // Смерть персонажа
    public override void Dead()
    {
        if (!playerIsLive)
        {
            speedX = 0;
            thisAnimator.SetBool("Dead", true);
        }
    }

    //Удаляем персонажа из сцены, вызывается из анимации смерти
    public void CharDestroy()
    {
        Destroy(gameObject);
    }
}