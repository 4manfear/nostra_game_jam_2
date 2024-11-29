using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cat_cuntrol : MonoBehaviour
{
    public float jumpForce = 10f; // Adjust as needed.
    private Rigidbody2D rb;
    public bool isGrounded; // Check if the player is on the ground.
    private int jumpCount = 0; // To track the number of jumps.

    [Header("Double Jump Ability")]
    public bool canDoubleJump = false; // Control whether double jump is allowed.

    [Header("UI Button for Jumping")]
    public Button jumpButton; // Reference to the Jump UI button.
    public Sprite normalButtonSprite; // Sprite for normal state.
    public Sprite doubleJumpButtonSprite; // Sprite for indicating double jump.

    [Header("Attack Ability")]
    [SerializeField]
    private float distance_to_attack;

    [Header("Food Counter Reference")]
    [SerializeField]
    private food_counter foodcounter;

    private Image buttonImage; // Reference to the Image component of the button.
    [Header("-------------------------------------------------------------------------------------------------------------")]
    [Header("the game over canvas/ panel")]
    public GameObject game_over_panel;

    [Header("pause menu panel")]
    public GameObject pause_menu;
    void Start()
    {

        game_over_panel.SetActive(false);

        rb = GetComponent<Rigidbody2D>();

        // Get the Image component of the button.
        if (jumpButton != null)
            buttonImage = jumpButton.GetComponent<Image>();

        // Set the button's initial sprite and active state.
        if (buttonImage != null && normalButtonSprite != null)
            buttonImage.sprite = normalButtonSprite;

        if (jumpButton != null)
            jumpButton.gameObject.SetActive(canDoubleJump);
    }

    private void Update()
    {
        if (foodcounter.cat_stage_2 == true || foodcounter.cat_stage_3 == true)
        {
            canDoubleJump = true;
        }
        else
        {
            canDoubleJump = false;
        }
        if (game_over_panel.activeSelf==true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Jump()
    {
        // Allow jumping if grounded or if double jump is enabled.
        if (jumpCount < 1 || (jumpCount == 1 && canDoubleJump))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;

            // Change the button's sprite to indicate double jump availability.
            if (jumpCount == 1 && canDoubleJump && buttonImage != null && doubleJumpButtonSprite != null)
            {
                buttonImage.sprite = doubleJumpButtonSprite;
                Debug.Log("Button sprite changed for double jump!");
            }

            // Reset the button sprite after double jump.
            if (jumpCount == 2 && buttonImage != null && normalButtonSprite != null)
            {
                buttonImage.sprite = normalButtonSprite;
                Debug.Log("Double jump executed, button sprite reset!");
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

            // Reset the button sprite to normal on landing.
            if (buttonImage != null && normalButtonSprite != null)
                buttonImage.sprite = normalButtonSprite;

            // Re-enable the jump button if double jump is enabled.
            if (jumpButton != null)
                jumpButton.gameObject.SetActive(canDoubleJump);
        }

        if (collision.gameObject.CompareTag("Mouse"))
        {
            game_over_panel.SetActive(true);
            //Destroy(this.gameObject);
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

        // Update the jump button state and sprite based on the ability.
        if (jumpButton != null)
        {
            jumpButton.gameObject.SetActive(canDoubleJump);

            if (buttonImage != null && normalButtonSprite != null)
                buttonImage.sprite = normalButtonSprite;
        }
    }


    public void pauseing_the_game()
    {
        Time.timeScale = 0f;
        pause_menu.SetActive(true);

    }

    public void resume_the_game()
    {
        Time.timeScale = 1f;
        pause_menu.SetActive(false);
    }

    public void re_start_level_button(int thissceneindexnumber)
    {
        SceneManager.LoadScene(thissceneindexnumber);
    }

    public void menu_button(int menusceen)
    {
        SceneManager.LoadScene(menusceen);
    }

    public void quit_button()
    {
        Application.Quit();
    }

}
