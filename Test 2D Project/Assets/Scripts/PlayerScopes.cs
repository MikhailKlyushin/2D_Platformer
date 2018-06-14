using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт кол-ва очков у игрока,
/// крепится к пустому объекту на сцене
/// </summary>

public class PlayerScopes : MonoBehaviour {

	private int myScopes;           // Общий счет очков

    public GameObject ScopePanelValue;   // Объект отображающий очки
    private Text scopeValue;        // Текст со значением

    void Start()
    {
        myScopes = 0;
        scopeValue = ScopePanelValue.GetComponent<Text>();
    }

    void FixedUpdate()
    {
        scopeValue.text = ScopesFormat(MyScopes);   // Вывод счета в формате
    }

    // Конструктор
    public int MyScopes
    {
        get { return myScopes; }
        set
        {
            myScopes = value;
        }
    }

    // Добавляем очки к общему счету
    public void AddedScopes(int scopes)
    {
        MyScopes = MyScopes + scopes;
    }

    // Вывод счета в формате "000000"
    private string ScopesFormat(int value)
    {
        string scopeString = value.ToString();
        while (scopeString.Length < 6)
        {
            scopeString = "0" + scopeString;
        }
        return scopeString;
    }
}
