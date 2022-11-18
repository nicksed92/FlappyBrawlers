using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Awake()
    {
        GlobalEvents.OnPlayerHit.AddListener(Show);
    }

    private void Show(int score)
    {
        _panel.SetActive(true);
    }
}
