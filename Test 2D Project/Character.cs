using System;
using System.Collections.Generic;
using UnityEngine;

class Character:MonoBehaviour
{
    public float maxSpeed = 10f;    //переменная для установки макс. скорости персонажа   
    public float jumpForce = 5f;    //переменная для установки силы прыжка персонажа  
    public float backPosition = 1.2f;   //переменная компенсирования смещения игрока при смене направления движения
    public bool isFacingRight = true;   //переменная для определения направления персонажа вправо/влево
    private bool isGrounded;
    public bool AttackAnimation;
    float speedX;   //переменная запоминающая направление движения
    //private Rigidbody2D rigidbody;
    //private Animator animator;  //ссылка на компонент анимаций

    public void Walking(float speedX)
    {
        transform.Translate(speedX / 100f, 0, 0);   //Движение персонажа с использованием метода transform
    }
}

