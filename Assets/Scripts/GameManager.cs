using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score = 0;

    public void GameOver()
    {
        Debug.Log("Game Over! Your score: " + score);
    }

    public void IncreaseScore()
    {
        score++;
    }
}
