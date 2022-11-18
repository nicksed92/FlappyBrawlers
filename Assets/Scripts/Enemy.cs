using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MoveSpeed { get => _moveSpeed; set { _moveSpeed = value; } }

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _lifeTime = 7f;
    [SerializeField] private float _moveMinY = 1f;
    [SerializeField] private float _moveMaxY = 1f;

    private bool isMoving = true;

    private void Awake()
    {
        GlobalEvents.OnPlayerHit.AddListener(StopMoving);
    }

    private void Start()
    {
        SetPositionY();
        StartCoroutine(Destroy());
    }

    private void FixedUpdate()
    {
        if (isMoving)
            Move();
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
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

    private void StopMoving()
    {
        isMoving = false;
        StopCoroutine(Destroy());
    }
}