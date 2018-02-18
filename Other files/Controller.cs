using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float horizontalSpeed;
    float speedX;
    public float verticalImpulse;
    Rigidbody2D rb;
    //KeyCode keyLeft = KeyCode.A;
    //KeyCode keyRight = KeyCode.D;
    //KeyCode keyJump = KeyCode.W;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LeftButtonDown()
    {
        speedX = -horizontalSpeed;
    }

    public void RightButtonDown()
    {
        speedX = horizontalSpeed;
    }

    public void JumpButtonDown()
    {
        rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
    }

    public void Stop()
    {
        speedX = 0;
    }

    void FixedUpdate()
    {
        transform.Translate(speedX, 0, 0);
    }
}
