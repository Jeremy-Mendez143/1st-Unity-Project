using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    public float moveSpeed; // Movement speed of the player
    private bool isDashing = false; // Flag to check if the player is currently dashing
    public float dashSpeed = 10f; // Speed multiplier for dashing
    public float dashDuration = 0.5f; // Duration of the dash
    public float dashCooldown = 2f; // Cooldown time between dashes
    private float lastDashTime = 0f; // Time when the last dash occurred

    // Rigidbody and movement
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    public Vector2 moveDir; // Direction of player movement input

    //TODO: Move anything related to player movement into this script
    //Dash ability can maybe be its own script since we're adding special dashes based on the player's element

    // Time pausing variables
    private bool isTimePaused = false; // Flag to check if time is currently paused
    private float savedTimeScale; // Time scale value to restore when unpausing time

    //Last moved direction
    public Vector2 lastMovedVector;
    public float lastHorizontal;
    public float lastVertical;

    private void Awake()
    {
        lastMovedVector = new Vector2(1, 0f);

        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on the player GameObject
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3f; // Set the initial movement speed of the player
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement(); // Handle player input for movement and actions

        // Check if enough time has passed since the last dash and cooldown of dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > lastDashTime + dashCooldown)
        {
            StartCoroutine(Dash()); // Initiate the dash coroutine
        }

        // Toggle time pausing with a key (e.g., Left Control)
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ToggleTimePause(); // Toggle the time pausing state
        }
    }

    // FixedUpdate is called at fixed intervals for physics calculations
    private void FixedUpdate()
    {
        // Only move if time is not paused
        if (!isTimePaused)
        {
            Move(); // Move the player based on input
        }
    }

    // Handle player input for movement
    private void InputManagement()
    {
        float xMotion = Input.GetAxisRaw("Horizontal"); // Get horizontal input
        float yMotion = Input.GetAxisRaw("Vertical"); // Get vertical input

        moveDir = new Vector2(xMotion, yMotion);

        if (moveDir.x != 0)
        {
            lastHorizontal = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontal, 0f); //Last moved X
        }

        if (moveDir.y != 0)
        {
            lastVertical = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVertical); //Last moved Y
        }
    }

    // Move the player based on input
    private void Move()
    {
        rb.velocity = moveDir * moveSpeed; // Set the Rigidbody velocity for movement
    }

    // Coroutine for player dash ability
    private IEnumerator Dash()
    {
        if (!isDashing)
        {
            isDashing = true; // Set dashing flag to true
            lastDashTime = Time.time; // Record the time of the dash
            float originalMoveSpeed = moveSpeed; // Store the original move speed
            moveSpeed = dashSpeed; // Increase move speed for dashing

            yield return new WaitForSeconds(dashDuration); // Wait for dash duration

            moveSpeed = originalMoveSpeed; // Reset move speed after dash
            isDashing = false; // Reset dashing flag
        }
    }

    // Toggle time pausing on and off
    private void ToggleTimePause()
    {
        isTimePaused = !isTimePaused; // Toggle the time paused state

        if (isTimePaused)
        {
            // Pause time
            savedTimeScale = Time.timeScale; // Store current time scale
            Time.timeScale = 0f; // Set time scale to zero (pauses physics)
        }
        else
        {
            // Resume time
            Time.timeScale = savedTimeScale; // Restore previous time scale
        }
    }
}
