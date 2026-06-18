using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    public float sprintspeed = 20;
    public float jumpForce = 5f;

    public float maxStamina = 2f;
    public float stamina;

    private bool isGrounded = true;

    private Rigidbody rb;

    public Transform headTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stamina = maxStamina;
    }

    public void Update()
    {
        Debug.Log("Speed: " + speed);
        Debug.Log("Stamina: " + stamina);
        PlayerMovement();
        Jump();
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
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            speed = sprintspeed;
            stamina -= Time.deltaTime; // витрачаємо витривалість
        }
        else
        {
            speed = 10f;         
        }
        if (stamina <= 0)
        {
            speed = 10f;
        }
        if (!Input.GetKey(KeyCode.LeftShift) && stamina < maxStamina)
        {
            stamina += Time.deltaTime;
        }
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
