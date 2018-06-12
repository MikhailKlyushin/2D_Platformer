using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт области обнаружения игрока, крепится к области монтра
/// </summary>

public class FieldView : MonoBehaviour {

    public bool OnColisionTrue = false;

    public void OnTriggerStay2D(Collider2D collision)
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
