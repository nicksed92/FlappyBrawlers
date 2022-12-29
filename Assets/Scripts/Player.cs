using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private BonusSpawner _bonusSpawner;
    [SerializeField] private int _defaultPointsForSecond = 1;
    [SerializeField] private int _pointsForSecond;
    [SerializeField] private GameObject _bonusUI;
    [SerializeField] private YandexSDK _yandexSDK;

    public int Score { get; private set; } = 0;
    public List<int> UnlockedSkinsID { get; private set; } = new List<int>();
    public int EquipedSkinID { get; set; } = 0;

    private Rigidbody2D _rigidbody2D;
    private bool isPlaying = true;

    public void SpendScore(int value)
    {
        if (value < Score && value > 0)
            Score -= value;
    }

    public void AddUnlockedSkin()
    {
        UnlockedSkinsID.Add(UnlockedSkinsID.Count);

        SaveLoadData.SaveList(UnlockedSkinsID, SaveLoadData.SaveType.Skins);
    }

    private void Awake()
    {
        EquipedSkinID = SaveLoadData.LoadInt(SaveLoadData.SaveType.EquipedSkin);
        UnlockedSkinsID = SaveLoadData.LoadList(SaveLoadData.SaveType.Skins);

        GlobalEvents.OnStartClicked.AddListener(OnGameStart);
        GlobalEvents.OnBonusPickedUp.AddListener(OnBonusPickedUpHendler);
        YandexSDK.OnShowRewardedVideoSuccesAdv.AddListener(OnShowRewardedVideoSuccesAdvHandler);
    }

    private void OnShowRewardedVideoSuccesAdvHandler()
    {
        Score *= 2;
        GlobalEvents.OnScoreChanged?.Invoke(Score);
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _pointsForSecond = _defaultPointsForSecond;
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

    private void OnBonusPickedUpHendler(int multiplier, float duration)
    {
        StartCoroutine(PointMultiply(multiplier, duration));
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

    private IEnumerator PointMultiply(int multiplier, float duration)
    {
        SoundManager.Instance.PlaySound("BonusPickedUp");
        float timer = 0f;
        _pointsForSecond = _defaultPointsForSecond;
        _pointsForSecond *= multiplier;

        _bonusUI.SetActive(true);
        _bonusUI.transform.GetChild(0).GetComponent<Text>().text = $"x{multiplier}";

        while (duration > timer && isPlaying)
        {
            timer++;
            yield return new WaitForSeconds(1f); ;
        }

        _pointsForSecond = _defaultPointsForSecond;
        _bonusUI.SetActive(false);
    }

    private void GameOver()
    {
        _bonusSpawner.StopSpawn();
        SoundManager.Instance.StopAllMusic();

        isPlaying = false;

        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _rigidbody2D.simulated = false;

        int maxScore = SaveLoadData.LoadInt(SaveLoadData.SaveType.MaxScore);
        SaveLoadData.SaveInt(Score, SaveLoadData.SaveType.CurrentScore);

        if (Score > maxScore)
        {
            SaveLoadData.SaveInt(Score, SaveLoadData.SaveType.MaxScore);
        }
    }
}