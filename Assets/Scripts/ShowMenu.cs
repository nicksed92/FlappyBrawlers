using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Awake()
    {
        GlobalEvents.OnPlayerHit.AddListener(Show);
    }

    private void Show()
    {
        _panel.SetActive(true);
    }
}
