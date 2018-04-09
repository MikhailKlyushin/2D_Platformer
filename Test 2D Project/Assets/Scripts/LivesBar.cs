using UnityEngine;

/// <summary>
/// Скрипт управления вывода кол-ва жизней
/// </summary>

public class LivesBar : MonoBehaviour {

    private Transform[] hearts = new Transform[5];

    private Player2DController character;

    private void Awake()
    {
        character = FindObjectOfType<Player2DController>();

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < character.Lives)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
}
