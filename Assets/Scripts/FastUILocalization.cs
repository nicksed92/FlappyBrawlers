using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FastUILocalization : MonoBehaviour
{
    [SerializeField] private string EN;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GlobalStrings _globalStrings;

    private void Start()
    {
        _text.text = _globalStrings.GetString(EN);
    }
}