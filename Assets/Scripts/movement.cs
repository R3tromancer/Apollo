using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{

    [SerializeField] InputAction thrust;
    [SerializeField] InputAction pullUp;
    [SerializeField] InputAction pushDown;
    Rigidbody2D rigidbody2D;

    [SerializeField] float rotationAngle;
    [SerializeField] float thrustPower;
    [SerializeField] float inertiaPower;

    bool powered;


    void OnEnable()
    {
        thrust.Enable();
        pullUp.Enable();
        pushDown.Enable();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("PlaneMoveCollisoon");
        GetComponent<Health>().ReduceHealth(200);
    }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (thrust.IsPressed())
        {
            if (rigidbody2D.bodyType == RigidbodyType2D.Dynamic)
            {
                rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                rigidbody2D.linearVelocity = new Vector2(0, 0);
                powered = true;
            }
            transform.Translate(Vector3.right * thrustPower * Time.deltaTime);
        }

        else if (powered)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            rigidbody2D.AddRelativeForce(Vector2.right * inertiaPower * Time.deltaTime);
            Debug.Log("Powered");
            powered = false;
        }


        if (pullUp.IsPressed())
        {
            transform.Rotate(Vector3.forward * rotationAngle * Time.deltaTime);
        }

        if (pushDown.IsPressed())
        {
            transform.Rotate(Vector3.back * rotationAngle * Time.deltaTime);
        }
    }






    /*     void FixedUpdate()
        {
            if(thrust.IsPressed())
            {
                rigidbody2D.AddRelativeForce(Vector2.up * thrustPower * Time.fixedDeltaTime);

            }

            if(pullUp.IsPressed())
            {
                transform.Rotate(Vector3.forward * rotationAngle * Time.fixedDeltaTime);
            }

            if(pushDown.IsPressed())
            {
                transform.Rotate(Vector3.back * rotationAngle * Time.fixedDeltaTime);
            }
        } */
}
