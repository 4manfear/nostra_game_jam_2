
//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerJump : MonoBehaviour
//{
//<<<<<<< Updated upstream
//    public float jumpForce = 10f; // Adjust as needed.
//=======
//<<<<<<< HEAD
//    [Header("Jump Ability")]
//    public float jumpForce = 7f; // Adjust as needed
//=======
//    public float jumpForce = 10f; // Adjust as needed.
//>>>>>>> 78958b03e8e9121256bafa2519dd454f517775d3
//>>>>>>> Stashed changes
//    private Rigidbody2D rb;
//    public bool isGrounded; // Check if the player is on the ground.
//    private int jumpCount = 0; // To track the number of jumps.

//<<<<<<< Updated upstream
//=======
//<<<<<<< HEAD
//=======
//>>>>>>> Stashed changes
//    [Header("Double Jump Ability")]
//    public bool canDoubleJump = false; // Control whether double jump is allowed.

//    [Header("UI Components")]
//    public Button jumpButton; // Reference to the Jump UI button.

//<<<<<<< Updated upstream
//=======
//>>>>>>> 78958b03e8e9121256bafa2519dd454f517775d3
//>>>>>>> Stashed changes
//    [Header("Attack Ability")]
//    [SerializeField]
//    private float distance_to_attack;


//    public food_counter foodcount;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();

//        // Enable the jump button initially.
//        if (jumpButton != null)
//            jumpButton.gameObject.SetActive(true);
//    }

//<<<<<<< HEAD
//=======
//    private void Update()
//    {
//        if(!foodcount.cat_stage_1)
//        {
//            canDoubleJump = true;
//        }
//        else
//        {
//            canDoubleJump=false;
//        }
//    }

//>>>>>>> 78958b03e8e9121256bafa2519dd454f517775d3
//    public void Jump()
//    {
//        // Allow jumping if grounded or if double jump is enabled.
//        if (jumpCount < 1 || (jumpCount == 1 && canDoubleJump))
//        {
//            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//<<<<<<< Updated upstream
//=======
//<<<<<<< HEAD
//            isGrounded = false; // Prevent double jumps
//=======
//>>>>>>> Stashed changes
//            jumpCount++;

//            // If double jump has been executed, disable the button.
//            if (jumpCount == 2 && jumpButton != null && canDoubleJump)
//            {
//                jumpButton.gameObject.SetActive(false);
//                Debug.Log("Double jump executed!");
//            }
//<<<<<<< Updated upstream
//=======
//>>>>>>> 78958b03e8e9121256bafa2519dd454f517775d3
//>>>>>>> Stashed changes
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        // Ensure the player is grounded when touching a platform.
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = true;
//            jumpCount = 0; // Reset jump count on landing.

//            // Re-enable the jump button UI.
//            if (jumpButton != null)
//                jumpButton.gameObject.SetActive(true);
//        }
//    }

//    public void distance_checkerof_mouse()
//    {
//        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Mouse");

//        foreach (GameObject enemy in enemies)
//        {
//            // Calculate distance between player and the enemy.
//            float distance = Vector2.Distance(transform.position, enemy.transform.position);

//            // If within attack distance, destroy the enemy.
//            if (distance <= distance_to_attack)
//            {
//                Destroy(enemy);
//                Debug.Log("Enemy destroyed!");
//                break; // Destroy one enemy per attack.
//            }
//        }
//    }
//}
