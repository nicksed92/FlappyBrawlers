using UnityEngine.Events;

public class GlobalEvents
{
    public static UnityEvent<int> OnScoreChanged = new();
    public static UnityEvent OnPlayerHit = new();
    public static UnityEvent OnRestartLevel = new();
    public static UnityEvent OnStartClicked = new();
}