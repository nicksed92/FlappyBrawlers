using UnityEngine.Events;

public class GlobalEvents
{
    public static UnityEvent<int> OnPointsChanged = new();
    public static UnityEvent OnPlayerHit = new();
}