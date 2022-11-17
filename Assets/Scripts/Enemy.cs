using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _lifeTime = 7f;
    [SerializeField] private float _moveMinY = 1f;
    [SerializeField] private float _moveMaxY = 1f;

    private void Start()
    {
        SetPositionY();
        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            GlobalEvents.OnPlayerHit?.Invoke();
            Debug.Log("Hit");
        }
    }

    public void SetMoveSpeed(float value)
    {
        _moveSpeed = Mathf.Clamp(value, 0, int.MaxValue);
    }

    private void SetPositionY()
    {
        transform.position = new Vector2(transform.position.x, Utilites.GetRandomFloat(_moveMinY, _moveMaxY));
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x - _moveSpeed * Time.deltaTime, transform.position.y);
    }
}