using UnityEngine;

public class GameController : MonoBehaviour
{
    public void RestarlLevel()
    {
        SoundManager.Instance.PlayMusic("Main");
        ScenesManager.RestartScene();
    }
}