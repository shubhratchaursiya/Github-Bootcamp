using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Button startButton;
    public Button quitButton;
    public Text titleText;
    public Text highScoreText;
    
    void Start()
    {
        // Setup title
        if (titleText != null)
        {
            titleText.text = "Endless Runner";
        }
        
        // Display high score
        if (highScoreText != null)
        {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        
        // Setup buttons
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
        
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
    }
    
    void Update()
    {
        // Allow starting with spacebar or enter
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
        
        // Allow quitting with escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}