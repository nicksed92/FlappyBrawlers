using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        GlobalEvents.OnPointsChanged.AddListener(UpdateText);
        GlobalEvents.OnPlayerHit.AddListener(HideText);
    }

    void Start()
    {
        _text = GetComponent<Text>();
    }

    private void UpdateText(int score)
    {
        _text.text = score.ToString();
    }

    private void HideText(int score)
    {
        gameObject.SetActive(false);
    }
}