using UnityEngine;

public class RestartLevelButton : MonoBehaviour
{
    public void Restart()
    {
        GlobalEvents.OnRestartLevel?.Invoke();
    }
}