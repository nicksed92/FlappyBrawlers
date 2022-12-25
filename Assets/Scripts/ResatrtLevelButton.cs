using System.Collections;
using UnityEngine;

public class ResatrtLevelButton : MonoBehaviour
{
    [SerializeField] private GameObject _button;
    [SerializeField] private Player _player;
    [SerializeField] private SkinChanger _skinChanger;

    private void Awake()
    {
        GlobalEvents.OnScoreChanged.AddListener(OnScoreChangedHandler);
        GlobalEvents.OnPlayerHit.AddListener(OnPlayerHit);
    }

    private void OnPlayerHit()
    {
        if (_skinChanger.SkinTempatesCount == _player.UnlockedSkinsID.Count || _skinChanger.GetLastSkinPrice() > _player.Score)
            _button.SetActive(true);
        else
            _button.SetActive(false);
    }

    private void Start()
    {
        _button.SetActive(false);
    }

    private void OnScoreChangedHandler(int score)
    {
        int price = _skinChanger.GetLastSkinPrice();

        if (score < price || price == 0)
            _button.SetActive(true);
    }
}
