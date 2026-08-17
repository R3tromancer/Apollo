using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject blast;
    [SerializeField] int bombDamage;

    void OnTriggerEnter2D(Collider2D collision)
    { if(collision.gameObject.tag != "Player")
        {
        Instantiate(blast, transform.position - new Vector3(0, 1, 0), Quaternion.identity);
        if(collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<Health>().ReduceHealth(bombDamage);
        Destroy(gameObject);
        }
    }
}
