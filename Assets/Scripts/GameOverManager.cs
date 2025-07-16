using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Text finalScoreText;
    public Text gameOverText;
    public Button restartButton;
    public Button mainMenuButton;
    
    void Start()
    {
        // Get the final score from PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        
        // Update UI
        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + finalScore.ToString();
        }
        
        if (gameOverText != null)
        {
            gameOverText.text = "Game Over!";
        }
        
        // Setup buttons
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(LoadMainMenu);
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    void Update()
    {
        // Allow restart with spacebar or enter
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
        
        // Allow main menu with escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }
}