using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationsBlocks : MonoBehaviour
{

    private bool use = false;

    public GameObject Block;

    void Start()
    {
        transform.parent.gameObject.name = transform.parent.gameObject.name.Replace("(Clone)", "");
    }

    private void OnTriggerEnter()
    {
        if (!use)
        {
            Explosion(new Vector2(transform.position.x - 5, transform.position.y), 1.0f);
            Explosion(new Vector2(transform.position.x + 5, transform.position.y), 1.0f);
        }
    }

    void Explosion (Vector2 center, float radius)
    {
        Collider[] hitCollider = Physics.OverlapSphere(center, radius);
        if (hitCollider.Length == 0)
            Instantiate(Block, center, Quaternion.identity);
    }
}
