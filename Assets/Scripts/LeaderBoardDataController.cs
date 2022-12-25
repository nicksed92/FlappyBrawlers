using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Events;
using YandexLeaderBoard;

public class LeaderBoardDataController : MonoBehaviour
{
    [SerializeField] private LeaderBoardData _leaderBoard;

    public static UnityEvent<LeaderBoardData> OnLeaderBoardDataWritten = new UnityEvent<LeaderBoardData>();

    private void Awake()
    {
        YandexSDK.OnLeaderBoardGetData.AddListener(OnLeaderBoardGetDataHandler);
    }

    private void OnLeaderBoardGetDataHandler(string data)
    {
        _leaderBoard = JsonConvert.DeserializeObject<LeaderBoardData>(data);
        OnLeaderBoardDataWritten.Invoke(_leaderBoard);
    }
}
