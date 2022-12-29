using UnityEngine;
using UnityEngine.UI;

public class VideoRewardedPanel : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private GlobalStrings _globalStrings;
    [SerializeField] private Player _player;

    private void Awake()
    {
        YandexSDK.OnShowRewardedVideoSuccesAdv.AddListener(OnShowRewardedVideoSuccesAdvHandler);
    }

    private void OnEnable()
    {
        _scoreText.text = _globalStrings.GetString("Score") + ": " + _player.Score.ToString();
    }

    private void OnShowRewardedVideoSuccesAdvHandler()
    {
        SoundManager.Instance.PlaySound("Success");
        gameObject.SetActive(false);
    }
}
