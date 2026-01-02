using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector3 playerPosition;
    public float gravaity = -9.81f;
    public float jumpHeight = 5.0f;

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
}
