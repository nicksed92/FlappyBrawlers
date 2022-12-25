using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using YandexLeaderBoard;

[RequireComponent(typeof(Button))]
public class SendRecordButton : MonoBehaviour
{
    [SerializeField] private YandexSDK _yandexSDK;
    [SerializeField] private Button _button;

    private int _maxScore;

    public void OnSendRecordButtonClick()
    {
        _yandexSDK.SendValueToLeaderBoard(_maxScore);
    }

    private void Awake()
    {
        LeaderBoardDataController.OnLeaderBoardDataWritten.AddListener(OnLeaderBoardDataWrittenHandler);
    }

    private void OnLeaderBoardDataWrittenHandler(LeaderBoardData leaderBoardData)
    {
        _maxScore = SaveLoadData.LoadInt(SaveLoadData.SaveType.MaxScore);

        int userScore = leaderBoardData.Entries.FirstOrDefault(entry => entry.Rank == leaderBoardData.UserRank).Score;

        if (_maxScore > userScore)
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {

    }
}
