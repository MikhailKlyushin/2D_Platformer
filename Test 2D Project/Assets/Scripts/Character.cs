using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private int lives = 5;

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 5)
            {
                lives = value;
            }
            livesBar.Refresh();
        }
    }

    private LivesBar livesBar;

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
    }
}
