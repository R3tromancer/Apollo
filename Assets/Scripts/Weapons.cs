using UnityEngine;
using UnityEngine.InputSystem;

public class Bomber : MonoBehaviour
{
    [Header("Bomb")]
    [SerializeField] private GameObject bomb;

    [Header("Gun")]
    [SerializeField] private Transform gunMuzzle;
    [SerializeField] private float fireRate = 15f;

    [Header("Input")]
    [SerializeField] private InputAction bombInput;
    [SerializeField] private InputAction fireInput;

    [SerializeField] private SpriteRenderer muzzleFlash;

    [SerializeField] private float muzzleFlashTime = 0.05f;

    private float flashTimer;

    private BulletPool bulletPool;
    private float nextShot;

    private void Awake()
    {
        bulletPool = GetComponent<BulletPool>();
    }

    private void OnEnable()
    {
        bombInput.Enable();
        fireInput.Enable();
    }

    private void OnDisable()
    {
        bombInput.Disable();
        fireInput.Disable();
    }

    private void Update()
    {
        // Bomb
        if (bombInput.WasPressedThisFrame())
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
        }

        // Gun
        if (fireInput.IsPressed() && Time.time >= nextShot)
        {
            nextShot = Time.time + (1f / fireRate);

            Bullet bullet = bulletPool.GetBullet();

            if (bullet != null)
            {
                bullet.Fire(
                    gunMuzzle.position,
                    gunMuzzle.rotation);

                // Show muzzle flash
                muzzleFlash.enabled = true;
                flashTimer = muzzleFlashTime;
            }
        }

        // Hide muzzle flash after its duration
        if (flashTimer > 0f)
        {
            flashTimer -= Time.deltaTime;

            if (flashTimer <= 0f)
            {
                muzzleFlash.enabled = false;
            }
        }
    }
}