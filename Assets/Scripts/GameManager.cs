using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Game Settings")]
    public int score = 0;
    public Text scoreText;
    public GameObject gameOverPanel;
    
    [Header("Spawning")]
    public GameObject[] obstaclePrefabs;
    public GameObject coinPrefab;
    public Transform spawnPoint;
    public float spawnDistance = 50f;
    public float minSpawnInterval = 2f;
    public float maxSpawnInterval = 4f;
    
    private bool isGameActive = true;
    private float nextSpawnTime;
    private Transform player;
    
    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        isGameActive = true;
        score = 0;
        UpdateScoreUI();
        
        // Find player
        player = FindObjectOfType<PlayerController>().transform;
        
        // Set next spawn time
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        
        // Hide game over panel if it exists
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
    
    void Update()
    {
        if (!isGameActive) return;
        
        // Spawn obstacles and coins
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomObject();
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
        
        // Clean up objects behind the player
        CleanupObjects();
    }
    
    void SpawnRandomObject()
    {
        if (spawnPoint == null) return;
        
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.z = player.position.z + spawnDistance;
        
        // Random lane (left, center, right)
        float[] lanes = { -2f, 0f, 2f };
        spawnPosition.x = lanes[Random.Range(0, lanes.Length)];
        
        // 70% chance for obstacle, 30% chance for coin
        if (Random.Range(0f, 1f) < 0.7f)
        {
            // Spawn obstacle
            if (obstaclePrefabs.Length > 0)
            {
                GameObject obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
                Instantiate(obstacle, spawnPosition, Quaternion.identity);
            }
        }
        else
        {
            // Spawn coin
            if (coinPrefab != null)
            {
                spawnPosition.y += 1f; // Raise coins slightly
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
    
    void CleanupObjects()
    {
        // Find and destroy objects that are far behind the player
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        
        foreach (GameObject obj in obstacles)
        {
            if (obj.transform.position.z < player.position.z - 20f)
            {
                Destroy(obj);
            }
        }
        
        foreach (GameObject obj in coins)
        {
            if (obj.transform.position.z < player.position.z - 20f)
            {
                Destroy(obj);
            }
        }
    }
    
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }
    
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
    
    public void GameOver()
    {
        isGameActive = false;
        
        // Stop the player
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.StopPlayer();
        }
        
        // Save final score for Game Over scene
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();
        
        // Show game over panel or load game over scene
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            // Load Game Over scene after a short delay
            Invoke("LoadGameOverScene", 2f);
        }
    }
    
    void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}