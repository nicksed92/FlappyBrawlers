using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class YandexSDK : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GetLeaderBoardData();

    [DllImport("__Internal")]
    private static extern void SetLeaderBoardValue(int score);

    [DllImport("__Internal")]
    private static extern void ShowFullScreenAdv();

    [DllImport("__Internal")]
    private static extern void ShowRewardedVideoAdv();

    public static UnityEvent<string> OnLeaderBoardGetData = new UnityEvent<string>();
    public static UnityEvent OnShowRewardedVideoSuccesAdv = new UnityEvent();

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

    public void OnShowRewardedVideoAdvClick()
    {
        ShowRewardedVideoAdv();
    }

    public void GetLeaderBoardDataHandler(string data)
    {
        OnLeaderBoardGetData.Invoke(data);
    }

    public void ShowRewardedVideoAdvSuccesHandler()
    {
        OnShowRewardedVideoSuccesAdv.Invoke();
    }

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR

        ShowFullScreenAdv();
#endif
    }
}