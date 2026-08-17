using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 50;

    private ObjectPool<Bullet> pool;

    private void Awake()
    {
        pool = new ObjectPool<Bullet>(
            CreateBullet,
            OnTakeBullet,
            OnReturnBullet,
            OnDestroyBullet,
            collectionCheck: false,
            defaultCapacity: defaultCapacity,
            maxSize: maxSize
        );
    }

    public Bullet GetBullet()
    {
        return pool.Get();
    }

    public void ReturnBullet(Bullet bullet)
    {
        pool.Release(bullet);
        Debug.Log("ReturnBullet");
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab);

        bullet.SetPool(this);

        return bullet;
    }

    private void OnTakeBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
                Debug.Log("OnBulletReutrn");
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        if (bullet)
            Destroy(bullet.gameObject);
    }
}