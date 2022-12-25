using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class YandexSDK : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GetLeaderBoardData();

    [DllImport("__Internal")]
    private static extern void SetLeaderBoardValue(int score);

    public static UnityEvent<string> OnLeaderBoardGetData = new UnityEvent<string>();

    public void OnLeaderBoardButtonClick()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        GetLeaderBoardData();
#endif
    }

    public void SendValueToLeaderBoard(int score)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        SetLeaderBoardValue(score);
#endif
    }

    public void GetLeaderBoardDataHandler(string data)
    {
        OnLeaderBoardGetData.Invoke(data);
    }
}