using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f; // Adjust as needed
    private Rigidbody2D rb;
    private bool isGrounded = true; // Check if the player is on the ground

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Prevent double jumps
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
}
