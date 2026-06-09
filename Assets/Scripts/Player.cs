using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    public float sprintspeed = 20;


    private Rigidbody rb;

    public Transform headTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        PlayerMovement();
        Sprint();
    }

    public void PlayerMovement()
    {
        Vector3 forward = headTransform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = headTransform.right;
        right.y = 0f;
        right.Normalize();

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-forward * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-right * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(right * speed);
        }

    }

    public void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintspeed;
        }
        else
        {
            speed = 10f;
        }
    }

   
}
