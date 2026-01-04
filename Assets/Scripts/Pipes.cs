using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public float leftBound;

    private void Start()
    {
        leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - 1.0f;
    }

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
