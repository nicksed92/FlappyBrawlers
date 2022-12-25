using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreText : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GlobalStrings _globalStrings;

    private void Awake()
    {
        GlobalEvents.OnScoreChanged.AddListener(SetText);
    }

    private void Start()
    {
        _text = _text.GetComponent<Text>();
    }

    private void SetText(int score)
    {
        //_text.text = "Score: " + score.ToString();
        _text.text = $"{_globalStrings.GetString("Score")}: {score}";
    }
}