using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    private int spritesIndex = 0;
    private Vector3 playerPosition;
    public float gravaity = -9.81f;
    public float jumpHeight = 5.0f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0.0f;
        transform.position = position;
        playerPosition = Vector3.zero;

    }
    private void Update()
    {
        bool pressed =
            (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) ||
            (Touchscreen.current != null &&
             Touchscreen.current.primaryTouch.press.wasPressedThisFrame);

        if (pressed)
        {
            playerPosition = Vector3.up * jumpHeight;
        }

        playerPosition.y += gravaity * Time.deltaTime;

        transform.position += playerPosition * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spritesIndex++;
        if (spritesIndex >= sprites.Length)
        {
            spritesIndex = 0;
        }

        spriteRenderer.sprite = sprites[spritesIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision Detected with " + collision.gameObject.name);
            FindFirstObjectByType<GameManager>().GameOver();
        }
        else if (collision.gameObject.CompareTag("Scoring"))
        {
            FindFirstObjectByType<GameManager>().IncreaseScore();
        }
    }
}
