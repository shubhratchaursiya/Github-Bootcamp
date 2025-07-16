using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 90f;
    public Vector3 rotationAxis = Vector3.up;
    
    [Header("Bobbing Effect")]
    public bool enableBobbing = true;
    public float bobbingSpeed = 2f;
    public float bobbingAmount = 0.5f;
    
    private Vector3 startPosition;
    
    void Start()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        // Rotate the coin
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
        
        // Add bobbing effect
        if (enableBobbing)
        {
            float newY = startPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}