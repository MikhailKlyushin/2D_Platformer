using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт вывода итогового счета в панеле завершения уровня,
/// крепится к контроллеру счета
/// </summary>

public class EndScope : MonoBehaviour
{

    public GameObject ActualScope;      // Наброное игроком значение 
    private Text actualScope;
    public GameObject EndScopeValue;    // Итоговое значение
    private Text scopeValue;

    void Start()
    {
        scopeValue = EndScopeValue.GetComponent<Text>();
        actualScope = ActualScope.GetComponent<Text>();
    }

    void FixedUpdate()
    {
        scopeValue.text = actualScope.text;
        Debug.Log("actualScope.text = " + actualScope.text);
    }
}
