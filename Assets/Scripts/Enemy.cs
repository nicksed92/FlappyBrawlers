using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lifeTime = 7f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = Mathf.Clamp(value, 0, int.MaxValue);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }
}
