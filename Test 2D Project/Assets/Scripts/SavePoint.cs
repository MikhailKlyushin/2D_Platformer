using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт точки сохранения
/// </summary>

public class SavePoint : MonoBehaviour {

    public Sprite saveOff;
    public Sprite saveOn;

    public bool saveActive = false;

    private SpriteRenderer thisSpriteRender;

	void Start () {

        thisSpriteRender = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player") && !saveActive)
        {
            thisSpriteRender.sprite = saveOn;
            saveActive = true;
        }
    }
}
