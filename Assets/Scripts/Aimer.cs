using System;
using UnityEngine;

public class Aimer : MonoBehaviour
{

    [SerializeField] movement player;
    [SerializeField] int MinuDegree = 180;
    Vector2 direction;
    float angle;

    bool firstShot = true;





    private BulletPool bulletPool;
    private float nextShot;
    [SerializeField] private Transform gunMuzzle;
    [SerializeField] private float fireRate = 1f;


    private void Awake()
    {
        bulletPool = GetComponent<BulletPool>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<movement>();

    }

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - MinuDegree);

        if (firstShot)
        {
            nextShot = Time.time + Mathf.Sin(transform.position.x + transform.position.y);
            firstShot = false;
        }

        Fire();

    }


    void Fire()
    {

        if (Time.time >= nextShot)
        {
            nextShot = Time.time + (1f / fireRate);

            Bullet bullet = bulletPool.GetBullet();

            if (bullet != null)
            {
                bullet.Fire(
                    gunMuzzle.position,
                    gunMuzzle.rotation);
            }
        }
    }

}
