using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 5.0f;
    public Transform cameraTransform; // Reference to the camera's transform
    public LayerMask groundMask; // Layer mask to specify what counts as ground
    public int gameOverSceneIndex = 1; // Build index of the scene to load when player falls below y = -5

    private Rigidbody rb;
    private bool isGrounded;
    private SceneChanger sceneChanger;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sceneChanger = FindObjectOfType<SceneChanger>(); // Find the SceneChanger in the scene

        if (sceneChanger == null)
        {
            Debug.LogError("SceneChanger script is missing in the scene.");
        }
    }

    void FixedUpdate()
    {
        // Check if the player is grounded
        // Use a raycast from the center of the sphere downwards to check for ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.1f, groundMask);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Get the camera's forward and right directions
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        // Remove any vertical component from the camera's direction
        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction relative to the camera's direction
        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal) * speed;

        rb.AddForce(movement);

        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Check if the player's y position is below -5 and load the game over scene
        if (transform.position.y < -5f)
        {
            if (sceneChanger != null)
            {
                sceneChanger.LoadScene(gameOverSceneIndex);
            }
        }
    }
}