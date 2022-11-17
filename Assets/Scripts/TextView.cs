using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextView : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        GlobalEvents.OnPointsChanged.AddListener(UpdateText);
    }

    void Start()
    {
        _text = GetComponent<Text>();
    }

    private void UpdateText(int points)
    {
        _text.text = points.ToString();
    }
}