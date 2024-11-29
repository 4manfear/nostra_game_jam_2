using UnityEngine;
using UnityEngine.UI;

public class MultiJump : MonoBehaviour
{
    public float jumpForce = 10f; // Adjust as needed
    private Rigidbody2D rb;
    private int jumpCount = 0; // Tracks the number of jumps
    public int maxJumps = 2; // Maximum allowed jumps
    public Button jumpButton; // Reference to the TMP button
    public Sprite singleJumpSprite; // Sprite when the first jump is possible
    public Sprite doubleJumpSprite; // Sprite when the double jump is possible

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateJumpButtonSprite();
    }

    public void Jump()
    {
        if (jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            UpdateJumpButtonSprite();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jumps when the player touches the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            UpdateJumpButtonSprite();
        }
    }

    private void UpdateJumpButtonSprite()
    {
        // Change the button image based on the jump count
        if (jumpButton != null && jumpButton.image != null)
        {
            if (jumpCount == 0)
            {
                jumpButton.image.sprite = singleJumpSprite; // Ready for the first jump
            }
            else if (jumpCount == 1)
            {
                jumpButton.image.sprite = doubleJumpSprite; // Ready for the double jump
            }
        }
    }
}

