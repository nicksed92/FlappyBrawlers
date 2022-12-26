using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BaseButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnClickHandler);
    }

    private void OnClickHandler()
    {
        SoundManager.Instance.PlaySound("Click");
    }
}
