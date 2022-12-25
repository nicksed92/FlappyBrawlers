using TMPro;
using UnityEngine;
using YandexLeaderBoard;

public class LeaderBoardPanel : MonoBehaviour
{
    [SerializeField] private LeaderBoardPlayerTemplate _leaderBoardPlayerTemplatePrefab;
    [SerializeField] private Transform _leaderBoardPlayerTemplatesContainer;
    [SerializeField] private TextMeshProUGUI _leaderBoardTitle;
    [SerializeField] private Localization _localization;
    [SerializeField] private GameObject _loadingPanel;

    public void OnClosePanelButtonClick()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        LeaderBoardDataController.OnLeaderBoardDataWritten.AddListener(OnLeaderBoardDataWrittenHandler);
    }

    private void Start()
    {
        _loadingPanel.SetActive(true);
    }

    private void OnLeaderBoardDataWrittenHandler(LeaderBoardData leaderBoardData)
    {
        if (_localization.CurrentLanguage == "ru")
            _leaderBoardTitle.text = leaderBoardData.Board.Title.Ru;
        else
            _leaderBoardTitle.text = leaderBoardData.Board.Title.En;

        foreach (Transform template in _leaderBoardPlayerTemplatesContainer)
        {
            Destroy(template.gameObject);
        }

        foreach (Entry entry in leaderBoardData.Entries)
        {
            LeaderBoardPlayerTemplate template = Instantiate(_leaderBoardPlayerTemplatePrefab, _leaderBoardPlayerTemplatesContainer);
            template.Init(entry.Rank, entry.Player.PublicName, entry.Score);
        }

        _loadingPanel.SetActive(false);
    }
}