using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float fadeOutTime = 0.25f;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, fadeOutTime);
        Destroy(gameObject);

        //check enemy hit
        //damage enemy
    }
}
