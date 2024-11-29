using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Cat_cuntrol : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    public bool isGrounded;
    private int jumpCount = 0;

    [Header("Double Jump Ability")]
    public bool canDoubleJump = false;

    [Header("UI Button for Jumping")]
    public Button jumpButton;

    [Header("Attack Ability")]
    [SerializeField]
    private float attackDistance;

    [Header("Food Counter Reference")]
    [SerializeField]
    private food_counter foodCounter;

    [Header("Game Over Panel")]
    public GameObject gameOverPanel;

    [Header("Pause Menu Panel")]
    public GameObject pauseMenu;

    private void Awake()
    {
        if (jumpButton != null)
        {
            // Ensure the jump button is always active at the start
            jumpButton.gameObject.SetActive(true);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        // Activate double jump ability when conditions are met (e.g., stages 2 or 3)
        if (foodCounter != null && (foodCounter.cat_stage_2 || foodCounter.cat_stage_3))
        {
            canDoubleJump = true;
        }
        else
        {
            canDoubleJump = false;
        }

        // Handle Time.timeScale logic (pausing the game on game over)
        if (gameOverPanel != null && gameOverPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else if (pauseMenu == null || !pauseMenu.activeSelf)
        {
            Time.timeScale = 1f;
        }

        // Ensure jump button is active if grounded or double jump is allowed
        if (isGrounded || canDoubleJump)
        {
            if (jumpButton != null)
            {
                jumpButton.gameObject.SetActive(true);
            }
        }
        else
        {
            if (jumpButton != null)
            {
                jumpButton.gameObject.SetActive(false);
            }
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            // Reset jump count when the player is grounded (first jump)
            jumpCount = 1;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // Perform the first jump
        }
        else if (canDoubleJump && jumpCount == 1) // If we are in the air and double jump is available
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Perform the double jump
            jumpCount = 2; // Increment jump count after double jump
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reset jump count when grounded
        }

        if (collision.gameObject.CompareTag("Mouse"))
        {
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void CheckMouseDistance()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Mouse");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance <= attackDistance)
            {
                Destroy(enemy);
                break;
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        if (pauseMenu != null)
            pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }

    public void RestartLevel(int sceneIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
        Debug.Log("button_press_huaaa");

    }

    public void LoadMenu(int menuSceneIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneIndex);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

