using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField] GameObject blast;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(blast, transform.position, Quaternion.identity);
        if(collision.gameObject.tag == "Enemy")
            Destroy(collision.gameObject);
        Destroy(gameObject);
    }
    
}
