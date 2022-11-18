using UnityEngine;

public class ClickWaitingPanel : MonoBehaviour
{
    public void OnClick()
    {
        GlobalEvents.OnStartClicked?.Invoke();
        gameObject.SetActive(false);
    }
}
