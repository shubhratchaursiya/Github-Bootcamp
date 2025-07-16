using UnityEngine;
using System.Collections.Generic;

public class GroundGenerator : MonoBehaviour
{
    [Header("Ground Settings")]
    public GameObject groundPrefab;
    public int groundSegmentsInScene = 10;
    public float groundSegmentLength = 10f;
    public float groundWidth = 8f;
    
    private Transform player;
    private List<GameObject> groundSegments = new List<GameObject>();
    private float nextGroundZ;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        
        // Create initial ground segments
        for (int i = 0; i < groundSegmentsInScene; i++)
        {
            SpawnGroundSegment();
        }
    }
    
    void Update()
    {
        // Check if we need to spawn more ground
        if (player.position.z > nextGroundZ - (groundSegmentsInScene * groundSegmentLength * 0.5f))
        {
            SpawnGroundSegment();
            RemoveOldGroundSegment();
        }
    }
    
    void SpawnGroundSegment()
    {
        GameObject newGround;
        
        if (groundPrefab != null)
        {
            newGround = Instantiate(groundPrefab, new Vector3(0, 0, nextGroundZ), Quaternion.identity);
        }
        else
        {
            // Create a simple ground segment if no prefab is provided
            newGround = GameObject.CreatePrimitive(PrimitiveType.Plane);
            newGround.transform.position = new Vector3(0, 0, nextGroundZ);
            newGround.transform.localScale = new Vector3(groundWidth * 0.1f, 1, groundSegmentLength * 0.1f);
            newGround.name = "Ground Segment";
            
            // Add a material or color
            Renderer renderer = newGround.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = new Color(0.2f, 0.6f, 0.2f); // Green ground
            }
        }
        
        groundSegments.Add(newGround);
        nextGroundZ += groundSegmentLength;
    }
    
    void RemoveOldGroundSegment()
    {
        if (groundSegments.Count > groundSegmentsInScene)
        {
            GameObject oldGround = groundSegments[0];
            groundSegments.RemoveAt(0);
            Destroy(oldGround);
        }
    }
}