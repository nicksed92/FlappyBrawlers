using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private GameObject _clickPanel;

    private Rigidbody2D rb2D;
    private float angle;
    float velocityY;

    private bool _isCanJump = true;

    private void Awake()
    {
        GlobalEvents.OnPlayerHit.AddListener(HidePanel);
        GlobalEvents.OnStartClicked.AddListener(OnScreenClick);
    }

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

    private void HidePanel()
    {
        _clickPanel.SetActive(false);
    }

    public void SetCanJumpState()
    {
        _isCanJump = true;
    }

    public void OnScreenClick()
    {
        if (_isCanJump)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.velocity = Vector2.up * jumpForce;

            SoundManager.Instance.PlaySound("Jump");

            _isCanJump = false;
        }
    }
}
