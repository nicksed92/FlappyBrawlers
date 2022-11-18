using UnityEngine.Events;

public class GlobalEvents
{
    public static UnityEvent<int> OnPointsChanged = new();
    public static UnityEvent<int> OnPlayerHit = new();
    public static UnityEvent OnRestartLevel = new();
}