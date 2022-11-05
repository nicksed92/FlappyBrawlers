using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D rb2D;
    private float angle;
    float velocityY;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        velocityY = rb2D.velocity.y;
        angle = velocityY;

        if (velocityY < 0)
            angle = velocityY * 5f;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnScreenClick()
    {
        rb2D.velocity = Vector2.zero;
        rb2D.velocity = Vector2.up * jumpForce;
    }
}
