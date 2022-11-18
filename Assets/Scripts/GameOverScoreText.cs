using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreText : MonoBehaviour
{
    [SerializeField] private Text _text;

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
        _text.text = "Score: " + score.ToString();
    }
}
