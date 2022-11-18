using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int Score { get; set; } = 0;
    public List<int> UnlockedSkinsID { get; } = new() { 0 };
    public int EquipedSkinID { get; set; } = 0;
    public bool isPlaying = true;

    [SerializeField] private int _pointsForSecond = 1;
    [SerializeField] private SkinChanger _skinChanger;

    private Rigidbody2D _rigidbody2D;

    public void AddUnlockedSkin()
    {
        UnlockedSkinsID.Add(UnlockedSkinsID.Count);
    }

    private void Awake()
    {
        GlobalEvents.OnStartClicked.AddListener(OnGameStart);
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameOver();
            GlobalEvents.OnPlayerHit?.Invoke();
        }
    }

    private void OnGameStart()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2D.simulated = true;
        StartCoroutine(AddPoints());
    }

    private IEnumerator AddPoints()
    {
        while (isPlaying)
        {
            Score += _pointsForSecond;
            GlobalEvents.OnScoreChanged?.Invoke(Score);
            yield return new WaitForSeconds(1);
        }
    }

    private void GameOver()
    {
        StopCoroutine(AddPoints());
        isPlaying = false;

        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _rigidbody2D.simulated = false;
        isPlaying = false;
    }
}
