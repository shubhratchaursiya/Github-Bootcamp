using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Follow Settings")]
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 0.125f;
    
    [Header("Look Settings")]
    public bool lookAtTarget = true;
    public Vector3 lookOffset = Vector3.zero;
    
    void Start()
    {
        if (target == null)
        {
            // Try to find the player automatically
            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                target = player.transform;
            }
        }
    }
    
    void LateUpdate()
    {
        if (target == null) return;
        
        // Calculate desired position
        Vector3 desiredPosition = target.position + offset;
        
        // Smoothly move towards the target
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
        // Look at the target
        if (lookAtTarget)
        {
            Vector3 lookAtPosition = target.position + lookOffset;
            transform.LookAt(lookAtPosition);
        }
    }
}