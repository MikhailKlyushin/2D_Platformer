using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationComtroller : MonoBehaviour {

    public bool AttackAnimation;

    public void AttackAniationTrue()
    {
        AttackAnimation = true;
    }

    public void AttackAniationFalse()
    {
        AttackAnimation = false;
    }
}
