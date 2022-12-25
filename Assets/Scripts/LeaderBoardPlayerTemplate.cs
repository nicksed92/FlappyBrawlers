using TMPro;
using UnityEngine;

public class LeaderBoardPlayerTemplate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _rank;
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _score;

    public int Rank { get; private set; }
    public string Name { get; private set; }
    public int Score { get; private set; }

    public void Init(int rank, string name, int score)
    {
        _rank.text = $"{rank}.";
        _name.text = name;
        _score.text = score.ToString();
    }
}
