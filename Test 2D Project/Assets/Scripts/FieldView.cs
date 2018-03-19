using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldView : MonoBehaviour {

    public bool OnColisionTrue = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnColisionTrue = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnColisionTrue = false;
    }
}
