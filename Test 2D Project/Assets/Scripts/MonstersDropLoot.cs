using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersDropLoot : MonoBehaviour {

    public GameObject oneHeal;
    public GameObject twoHeal;
    public GameObject fiveHeal;
 
    public void DropHeals(float positionX, float positionY)
    {
        int rnd = Random.Range(0, 9);
        Debug.Log("rnd = " + rnd);

        if (rnd <= 0)   // 10%
        {
            Instantiate(fiveHeal, new Vector2(positionX, positionY), Quaternion.identity);
        }
        else if ((rnd > 0) && (rnd <= 2))   // 20%
        {
            Instantiate(twoHeal, new Vector2(positionX, positionY), Quaternion.identity);
        }
        else if ((rnd > 2) && (rnd <= 5))   // 30%
        {
            Instantiate(oneHeal, new Vector2(positionX, positionY), Quaternion.identity);
        }
    }
}
