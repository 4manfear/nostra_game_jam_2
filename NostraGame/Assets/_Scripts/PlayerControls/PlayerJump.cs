
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f; // Adjust as needed
    private Rigidbody2D rb;
    private bool isGrounded = true; // Check if the player is on the ground

    [Header("attack_ability")]
    [SerializeField]
    private float distance_to_attack;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Prevent double jumps
            Debug.Log("jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ensure the player is grounded when touching a platform
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void distance_checkerof_mouse()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Mouse");

        foreach (GameObject enemy in enemies)
        {
            // Calculate distance between player and the enemy
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            // If within attack distance, destroy the enemy
            if (distance <= distance_to_attack)
            {
                Destroy(enemy);
                Debug.Log("Enemy destroyed!");
                break; // Destroy one enemy per attack
            }
        }
    }
}
