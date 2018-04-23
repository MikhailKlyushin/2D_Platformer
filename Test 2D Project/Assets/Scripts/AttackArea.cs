using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour {

    public bool OnColisionTrue = false;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            OnColisionTrue = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnColisionTrue = false;
    }
}
