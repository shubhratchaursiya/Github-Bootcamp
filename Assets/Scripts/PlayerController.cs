using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float sideSpeed = 5f;
    public float minX = -4f;
    public float maxX = 4f;
    
    private Rigidbody rb;
    private float horizontalInput;
    private bool isGameActive = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Ensure we have a Rigidbody
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        
        // Freeze rotation to prevent tumbling
        rb.freezeRotation = true;
    }
    
    void Update()
    {
        if (!isGameActive) return;
        
        // Get input
        horizontalInput = Input.GetAxis("Horizontal");
        
        // Alternative key inputs
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            horizontalInput = -1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            horizontalInput = 1f;
    }
    
    void FixedUpdate()
    {
        if (!isGameActive) return;
        
        // Forward movement
        Vector3 forwardMovement = transform.forward * forwardSpeed * Time.fixedDeltaTime;
        
        // Side movement
        Vector3 sideMovement = transform.right * horizontalInput * sideSpeed * Time.fixedDeltaTime;
        
        // Apply movement
        rb.MovePosition(rb.position + forwardMovement + sideMovement);
        
        // Clamp position to stay within bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Game Over
            isGameActive = false;
            GameManager.Instance.GameOver();
        }
        else if (other.CompareTag("Coin"))
        {
            // Collect coin
            GameManager.Instance.AddScore(10);
            Destroy(other.gameObject);
        }
    }
    
    public void StopPlayer()
    {
        isGameActive = false;
        rb.velocity = Vector3.zero;
    }
}