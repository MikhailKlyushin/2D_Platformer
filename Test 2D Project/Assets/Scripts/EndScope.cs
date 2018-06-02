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
    public GameObject DeadScopeValue;   // Значение после смерти персонажа
    private Text deadScope;

    void Start()
    {
        scopeValue = EndScopeValue.GetComponent<Text>();
        actualScope = ActualScope.GetComponent<Text>();
        deadScope = DeadScopeValue.GetComponent<Text>();
    }

    void FixedUpdate()
    {
        // Передаем значение в панели
        scopeValue.text = actualScope.text;
        deadScope.text = actualScope.text;
    }
}
