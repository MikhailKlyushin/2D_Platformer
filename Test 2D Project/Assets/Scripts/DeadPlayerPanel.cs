using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayerPanel : MonoBehaviour {

    public GameObject deadPlayerPanel;

    private GameObject player;
    private PlayerHp playerHp;

	void Start () {

        player = GameObject.FindWithTag("Player");
        playerHp = player.GetComponent<PlayerHp>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (playerHp.Lives <= 0)
        {
            deadPlayerPanel.SetActive(true);
        }
	}
}
