using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    public float sprintspeed = 13;
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
        
        Sprint();
        PlayerMovement();
        Jump();
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
           rb.linearVelocity = forward * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocity = -forward * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = -right * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = right * speed;
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
            speed = 5f;         
        }
        if (stamina <= 0)
        {
            speed = 5f;
        }
        if (!Input.GetKey(KeyCode.LeftShift) && stamina < maxStamina)
        {
            stamina += Time.deltaTime * 0.25f;// * 0.25 заповільнює зявляння витривалості (щоб пришвидшити треба збільшити)
        }
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && stamina >= 0.5f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            stamina -= 0.5f;
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
