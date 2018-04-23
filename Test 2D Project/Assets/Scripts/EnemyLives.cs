using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLives : MonoBehaviour {

    public int lives;

    private ZombieAI zombie;

    public void EnemyDamage()
    {
        zombie.Damage();
    }
}
