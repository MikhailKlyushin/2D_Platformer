using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Главный скрипт монстра "Зомби", отвечает за действия и взаимодействие с игроком
/// </summary>

public class Zombie : MonstersMotor {

    public float maxSpeed = 10f;        // макс. скорость персонажа   
    public float jumpForce = 5f;        // сила прыжка персонажа  
    public float backValue = 0f;        // компенсирование смещения игрока при смене направления движения
    public float distanceAttack = 0.63f;// дистанция атаки
    public float attackDamage = 1;      // урон при атаке
    public bool isFacingRight = true;   // направление персонажа вправо/влево
    public float timeEffect = 0.3f;     // время эффекта повреждения
    private bool isGrounded;            // находится ли персонаж на земле
    private bool AttackAnimation;
    private float speedX;               // переменная запоминающая направление движения
    private bool playerIsLive = true;   // монстер должен знать, жив ли игрок

    private Rigidbody2D thisRigidbody;
    public Transform thisTransform;
    private Animator thisAnimator;      // ссылка на компонент анимаций
    private SpriteRenderer thisSpriteRender;

    private GameObject player;
    private Player playerScript;

    private Transform frontView;        // фронтальная облать
    private Transform backView;
    private Transform playerTransform;  

    private float frontVisibility;      // фронтальное растояние обнаружения игрока
    private float distanceThePlayer;    // дистанция до игрока

    private bool backColision;          // находится ли игрок сзади
    private float playerPositionX;      // позиция игрока по Х
    private float monsterPositionX;     // позиция монстра по Х

    private CharacterHp monsterHp;
    public MonsterScope monsterScope;
    public bool monsterIsLive = true;

    void Start()
    {
        thisSpriteRender = GetComponent<SpriteRenderer>();
        thisRigidbody = GetComponent<Rigidbody2D>();
        thisTransform = transform;
        thisAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        frontView = thisTransform.Find("FrontFieldView");
        frontVisibility = float.Parse(frontView.localScale.x.ToString());
        backView = thisTransform.Find("BackFieldView");
        playerScript = FindObjectOfType<Player>();
        monsterHp = GetComponent<CharacterHp>();
        monsterScope = GetComponent<MonsterScope>();
    }

    void Update()
    {
        backColision = backView.GetComponent<FieldView>().OnColisionTrue;
        distanceThePlayer = Vector2.Distance(thisTransform.position, playerTransform.transform.position);

        if (monsterIsLive)
        {
            isFacingRight = ModelTurn(thisTransform, isFacingRight, backColision, backValue);
        }

        playerPositionX = playerTransform.position.x;
        monsterPositionX = thisTransform.position.x;
        speedX = FrontCollisionControl(playerPositionX, monsterPositionX, isFacingRight, speedX, maxSpeed);
        playerIsLive = playerScript.playerIsLive;
        monsterIsLive = monsterHp.CharIsLive();
        Attack();
        Dead();
    }

    void FixedUpdate()
    {
        if ((distanceThePlayer < frontVisibility) && playerIsLive)
        {
            Run(thisTransform, speedX);
            thisAnimator.SetFloat("Speed", Mathf.Abs(speedX * 10));  // Вкл. анимацию бега
        }
        else
        {
            speedX = Stop();
            thisAnimator.SetFloat("Speed", 0);                      // Выкл. анимацию бега
        }
    }

    // Атака
    public override void Attack()
    {
        if ((distanceThePlayer <= distanceAttack) && (playerIsLive))
        {
            speedX = Stop();

            thisAnimator.SetFloat("Speed", 0);
            thisAnimator.SetBool("Attack", true);       // Вкл. анимацию удара            
        }
        else
        {
            thisAnimator.SetBool("Attack", false);      // Выкл. анимацию удара
        }
    }

    // Нанесение урона игроку, вызывается из анимации
    public override void SetDamage()
    {
        if ((distanceThePlayer <= distanceAttack) && (playerIsLive))
        {
            playerScript.GetDamage(attackDamage);
        }
    }

    // Получение урона
    public override void GetDamage(float damage)
    {
        if (monsterIsLive)
        {
            monsterHp.GetDamage(damage);
            DamageEffect(thisSpriteRender, thisRigidbody);     // Эффект получения урона
            Invoke("DamageOff", timeEffect);    // Выкл. эффекта            
        }
    }

    // Вызываем выключение эффекта, 
    private void DamageOff()
    {
        OffDamageEffect(thisSpriteRender);
    }

    // Смерть монстра
    public override void Dead()
    {
        if (!monsterIsLive)
        {
            speedX = 0;
            thisAnimator.SetBool("Dead", true);
            Destroy(thisRigidbody);
            Destroy(GetComponent<BoxCollider2D>());
        }
    }

    //Удаляем монстра из сцены, вызывается из анимации смерти
    public void CharDestroy()
    {
        Destroy(gameObject);
        monsterScope.SetScopes();   // Начисляем очки игроку
    }
}
