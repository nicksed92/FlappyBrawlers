using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private int _minMultiplier = 2;
    [SerializeField] private int _maxMultiplier = 32;
    [SerializeField] private float _bonusDurationTime = 10f;

    [SerializeField] private float _minMoveSpeedX;
    [SerializeField] private float _maxMoveSpeedX;
    [SerializeField] private float _minAmplitude;
    [SerializeField] private float _maxAmplitude;
    [SerializeField] private float _minFrequenz;
    [SerializeField] private float _maxFrequenz;

    private int _multiplier;

    private float _moveSpeedX;
    private float _amplitude;
    private float _frequenz;

    private float _x, _y;

    private void Start()
    {
        _multiplier = Utilites.GetRandomInt(_minMultiplier, _maxMultiplier);
        _moveSpeedX = Utilites.GetRandomFloat(_minMoveSpeedX, _maxMoveSpeedX);
        _amplitude = Utilites.GetRandomFloat(_minAmplitude, _maxAmplitude);
        _frequenz = Utilites.GetRandomFloat(_minFrequenz, _maxFrequenz);

        Destroy(gameObject, 15f);
    }

    private void Update()
    {
        _x = transform.position.x;
        _y = transform.position.y;

        _x += _moveSpeedX * Time.deltaTime;
        _y = Mathf.Sin(_x * _frequenz) * _amplitude;
        transform.position = new Vector3(_x, _y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.TryGetComponent(out Player player))
        {
            GlobalEvents.OnBonusPickedUp.Invoke(_multiplier, _bonusDurationTime);
            Destroy(gameObject);
        }
    }
}
