using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт управления кнопками выбора уровня,
/// вешается на LevelBar(контейнер с кнопаками)
/// </summary>

public class LevelButtonManager : MonoBehaviour {

    public int countUnlockedLevel = 1;
    public static int numberSavedLevel = 1;

    [SerializeField]
    Sprite lockedIcon;

    [SerializeField]
    Sprite unlocedIcon;

    [SerializeField]
    Sprite saveIcon;

    [SerializeField]
    Sprite completeIcon;

    void Start () {

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i < countUnlockedLevel)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = unlocedIcon;
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().sprite = lockedIcon;
                transform.GetChild(i).GetComponent<Button>().interactable = false;
            }

            transform.GetChild(i).gameObject.name = (i + 1).ToString();
            transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
            transform.GetChild(i).GetComponent<LevelSettings>().numberLevel = (i + 1);
            transform.GetChild(i).GetComponent<LevelSettings>().RefreshLenght();
        }
	}
}
