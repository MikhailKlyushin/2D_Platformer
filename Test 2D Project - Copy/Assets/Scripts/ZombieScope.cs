using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт кол-ва даваемого очков
/// за убийство монстров
/// </summary>

public class ZombieScope : MonsterScope {

    public int scope = 50;
    private PlayerScopes playerScopes;

    void Start()
    {
        playerScopes = FindObjectOfType<PlayerScopes>();
    }

    public override void SetScopes()
    {
        playerScopes.AddedScopes(scope);
    }

}
