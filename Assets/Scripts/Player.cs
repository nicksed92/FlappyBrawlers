using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int Score { get; private set; } = 0;
    public List<int> UnlockedSkinsID { get; } = new() { 0 };
    public int EquipedSkinID { get; set; } = 0;
    public bool isPlaying = true;

    [SerializeField] private int _pointsForSecond = 1;

    private Rigidbody2D _rigidbody2D;

    public void AddUnlockedSkin()
    {
        UnlockedSkinsID.Add(UnlockedSkinsID.Count);
    }

    private void Awake()
    {
        GlobalEvents.OnPlayerHit.AddListener(GameOver);
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(AddPoints());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GlobalEvents.OnPlayerHit?.Invoke(Score);
        }
    }

    private IEnumerator AddPoints()
    {
        while (isPlaying)
        {
            yield return new WaitForSeconds(1);
            Score += _pointsForSecond;
            GlobalEvents.OnPointsChanged?.Invoke(Score);
        }
    }

    private void GameOver(int score)
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _rigidbody2D.simulated = false;
        isPlaying = false;
    }
}
