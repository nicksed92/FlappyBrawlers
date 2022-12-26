using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        GlobalEvents.OnScoreChanged.AddListener(UpdateText);
        GlobalEvents.OnPlayerHit.AddListener(HideText);
    }

    void Start()
    {
        _text = GetComponent<Text>();
    }

    private void UpdateText(int score)
    {
        _text.text = score.ToString();
        SoundManager.Instance.PlaySound("ScoreIncrement");
    }

    private void HideText()
    {
        gameObject.SetActive(false);
    }
}