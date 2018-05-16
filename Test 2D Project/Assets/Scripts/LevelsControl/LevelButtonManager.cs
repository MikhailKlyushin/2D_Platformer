using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт управления кнопками выбора уровня,
/// вешается на LevelBar(контейнер с кнопаками)
/// </summary>
public class LevelButtonManager : MonoBehaviour {

	void Start () {
		for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.name = (i + 1).ToString();
            transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
            transform.GetChild(i).GetComponent<LevelSettings>().numberLevel = (i + 1);
            transform.GetChild(i).GetComponent<LevelSettings>().RefreshLenght();
        }
	}
}
