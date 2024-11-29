using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat_cuntrol : MonoBehaviour
{
    public float jumpForce = 10f; // Adjust as needed.
    private Rigidbody2D rb;
    public bool isGrounded; // Check if the player is on the ground.
    private int jumpCount = 0; // To track the number of jumps.

    [Header("Double Jump Ability")]
    public bool canDoubleJump = false; // Control whether double jump is allowed.

    [Header("reference of the button which is making the catjump")]
    public Button jumpButton; // Reference to the Jump UI button.

    [Header("Attack Ability")]
    [SerializeField]
    private float distance_to_attack;

    [Header("food counter script reference")]
    [SerializeField]
    private food_counter foodcounter;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Set the button's active state based on the double jump ability.
        if (jumpButton != null)
            jumpButton.gameObject.SetActive(canDoubleJump);
    }
    private void Update()
    {
        if(foodcounter.cat_stage_2==true || foodcounter.cat_stage_3==true)
        {
            canDoubleJump = true;
        }
        else
        {
            canDoubleJump = false;
        }
        
    }

    public void Jump()
    {



        // Allow jumping if grounded or if double jump is enabled.
        if (jumpCount < 1 || (jumpCount == 1 && canDoubleJump))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;

            // If double jump has been executed, disable the button.
            if (jumpCount == 2 && jumpButton != null && canDoubleJump)
            {
                jumpButton.gameObject.SetActive(false);
                Debug.Log("Double jump executed!");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ensure the player is grounded when touching a platform.
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reset jump count on landing.

            // Re-enable the jump button if double jump is enabled.
            if (jumpButton != null)
                jumpButton.gameObject.SetActive(canDoubleJump);
        }
    }

    public void distance_checkerof_mouse()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Mouse");

        foreach (GameObject enemy in enemies)
        {
            // Calculate distance between player and the enemy.
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            // If within attack distance, destroy the enemy.
            if (distance <= distance_to_attack)
            {
                Destroy(enemy);
                Debug.Log("Enemy destroyed!");
                break; // Destroy one enemy per attack.
            }
        }
    }

    // Method to toggle the double jump ability dynamically.
    public void ToggleDoubleJump(bool enableDoubleJump)
    {
        canDoubleJump = enableDoubleJump;

        // Update the jump button state based on the ability.
        if (jumpButton != null)
            jumpButton.gameObject.SetActive(canDoubleJump);
    }
}
