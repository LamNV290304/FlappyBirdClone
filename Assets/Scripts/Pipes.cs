using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public float verticalSpeed = 1.0f; 
    public float verticalRange = 1.0f;
    private float randomOffset;
    public float maxTiltAngle = 15f;
    private float tiltAngle;

    public float leftBound;
    private float initialY;
    private GameManager gameManager;

    private void Start()
    {
        leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - 1.0f;
        initialY = transform.position.y;
        randomOffset = Random.Range(0f, 2f * Mathf.PI);
        tiltAngle = Random.Range(-maxTiltAngle, maxTiltAngle);

        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if(gameManager != null && gameManager.score >= (int) ScoreCheckpoint.ScoreCheck1 && gameManager.score < (int)ScoreCheckpoint.ScoreCheck2)
        {
            float newY = initialY + Mathf.Sin(Time.time * verticalSpeed) * verticalRange;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        } 
        else if (gameManager != null && gameManager.score >= (int)ScoreCheckpoint.ScoreCheck2)
        {
            float newY = initialY + Mathf.Sin((Time.time * verticalSpeed) + randomOffset) * verticalRange;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

        if (gameManager != null && gameManager.score >= (int)ScoreCheckpoint.ScoreCheck3)
        {
            transform.rotation = Quaternion.Euler(0, 0, tiltAngle);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
