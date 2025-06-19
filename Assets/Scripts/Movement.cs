using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement_speed;
    [SerializeField] float walk_speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 player_movement;
    [SerializeField] bool isGrounded = true;
    [SerializeField] float run_speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody>();
        movement_speed = walk_speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            rb.AddForce(Vector3.up * 770f);
            isGrounded = false;
            Debug.Log("JUMPED!!!");
        }

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            movement_speed = run_speed;
            Debug.Log("Running!");
        }

        else
        {
            movement_speed = walk_speed;
            Debug.Log("Walking!");
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(player_movement.x * movement_speed, rb.linearVelocity.y, player_movement.z *  movement_speed);

        float Xmovement = Input.GetAxis("Horizontal");
        float Zmovement = Input.GetAxis("Vertical");

        player_movement = new Vector3(Xmovement, 0f, Zmovement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
            Debug.Log("On the ground!!");
        }
    }
}
