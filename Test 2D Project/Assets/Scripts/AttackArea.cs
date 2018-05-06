using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour {

    public bool OnColisionTrue = false;
    public CharactersMotor childrelCharMotor;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            childrelCharMotor = collision.gameObject.GetComponent<CharactersMotor>();
            OnColisionTrue = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnColisionTrue = false;
    }
}
