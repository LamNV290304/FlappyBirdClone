using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text scoreText;

    public GameObject playButton;
    public GameObject gameOverText;

    private int score;

    public void Awake()
    {
        score = 0;
    }

    public void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void StartGame()
    {
        score = 0;
        playButton.SetActive(false);
        gameOverText.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        playButton.SetActive(true);
    }

    public void GameOver()
    {
        Debug.Log("Game Over! Your score: " + score);
    }

    public void IncreaseScore()
    {
        score++;
    }
}
