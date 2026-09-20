using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    [SerializeField] private float lifetime = 2f;

    [SerializeField] int bulletDamage = 1;


    private BulletPool pool;

    private float timer;

    public void SetPool(BulletPool bulletPool)
    {
        pool = bulletPool;
    }

    public void Fire(Vector2 position, Quaternion rotation)
    {
        transform.SetPositionAndRotation(position, rotation);
        Debug.Log("BulletFire");

        timer = lifetime;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        timer -= Time.deltaTime;
        Debug.Log("BulletUpdate1");

        if (timer <= 0f)
        {
            Debug.Log("BulletUpdate2");
            pool.ReturnBullet(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bullet Trigger");
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().ReduceHealth(bulletDamage);
            pool.ReturnBullet(this);

        }

    }
}