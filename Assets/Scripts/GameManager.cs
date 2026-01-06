using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;

    public GameObject playButton;
    public GameObject gameOverText;

    private int score;

    public void Awake()
    {
        score = 0;
        Application.targetFrameRate = 60;

        PauseGame();
    }

    public void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void StartGame()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOverText.SetActive(false);
        Time.timeScale = 1.0f;

        player.enabled = true;

        Pipes[] pipes = Object.FindObjectsByType<Pipes>(FindObjectsSortMode.None);

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        playButton.SetActive(true);

        PauseGame();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
