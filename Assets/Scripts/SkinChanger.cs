using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    public Sprite[] _skins;

    [SerializeField] private float _startScrollPositionX;
    [SerializeField] private GameObject _skinTemplate;
    [SerializeField] private Transform _content;
    [SerializeField] private int _ckinsCostMultiplier = 25;

    private Player _player;
    private RectTransform _rectTransform;
    private List<SkinTemplate> _skinTemplates = new();

    private void Awake()
    {
        GlobalEvents.OnPlayerHit.AddListener(SetInteractiveButtons);
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _player.GetComponent<SpriteRenderer>().sprite = _skins[_player.EquipedSkinID];
        _rectTransform = _content.GetComponent<RectTransform>();
        _rectTransform.anchoredPosition = new Vector3(_startScrollPositionX, 0, 0);

        if (PlayerPrefs.HasKey("skinID"))
            _player.GetComponent<SpriteRenderer>().sprite = _skins[PlayerPrefs.GetInt("skinID")];

        StartCoroutine(InitSkins());
    }

    private void SetInteractiveButtons()
    {
        for (int i = 0; i < _skinTemplates.Count; i++)
        {
            if (_player.Score >= _skinTemplates[i].PointsForUnlock && _skinTemplates[i].ButtonID != _player.EquipedSkinID && _player.UnlockedSkinsID.Contains(i - 1))
                _skinTemplates[i].Button.interactable = true;
        }
    }

    private IEnumerator InitSkins()
    {
        CreateTemplates();
        ShowUnlockedSkins();

        yield return null;
    }

    private void CreateTemplates()
    {
        for (int i = 0; i < _skins.Length; i++)
        {
            GameObject template = Instantiate(_skinTemplate, _content);

            SkinTemplate skinTemplate = new()
            {
                Button = template.transform.GetChild(1).GetComponent<Button>(),
                Text = template.transform.GetChild(1).GetComponent<Button>().transform.GetChild(0).GetComponent<Text>(),
                Image = template.transform.GetChild(0).GetComponent<Image>(),
                ButtonID = i,
                PointsForUnlock = i * _ckinsCostMultiplier
            };

            _skinTemplates.Add(skinTemplate);

            skinTemplate.Image.sprite = _skins[i];
            skinTemplate.Image.color = Color.black;

            skinTemplate.Text.text = skinTemplate.PointsForUnlock.ToString();

            skinTemplate.Button.onClick.AddListener(() => EquipSkin(skinTemplate.ButtonID));
        }
    }

    private void ShowUnlockedSkins()
    {
        for (int i = 0; i < _player.UnlockedSkinsID.Count; i++)
        {
            _skinTemplates[i].Image.color = Color.white;
            _skinTemplates[i].Button.interactable = true;
            _skinTemplates[i].Text.text = "Equip";

            if (i == _player.EquipedSkinID)
            {
                _skinTemplates[i].Text.text = "Equiped";
                _skinTemplates[i].Button.interactable = false;
            }
        }
    }

    private void EquipSkin(int id)
    {
        if (_player.UnlockedSkinsID.Contains(id) == false)
        {
            _player.Score -= _skinTemplates[id].PointsForUnlock;
            _player.AddUnlockedSkin();
            GlobalEvents.OnScoreChanged?.Invoke(_player.Score);
            SetInteractiveButtons();
        }
        else
        {
            _player.EquipedSkinID = id;
            PlayerPrefs.SetInt("skinID", id);
            //_player.GetComponent<SpriteRenderer>().sprite = _skins[id];
        }

        ShowUnlockedSkins();
    }
}