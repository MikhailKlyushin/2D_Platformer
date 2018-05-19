using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт кол-ва очков у игрока,
/// крепится к пустому объекту на сцене
/// </summary>

public class PlayerScopes : MonoBehaviour {

	private int myScopes;

    public int MyScopes
    {
        get { return myScopes; }
        set
        {
            myScopes = value;
        }
    }

    public void AddedScopes(int scopes)
    {
        MyScopes = MyScopes + scopes;
    }

    void FixedUpdate()
    {
        Debug.Log("MyScopes = " + MyScopes);
    }
}
