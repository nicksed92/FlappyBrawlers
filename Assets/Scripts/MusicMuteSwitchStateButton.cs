using System;
using UnityEngine;
using UnityEngine.UI;

public class MusicMuteSwitchStateButton : MonoBehaviour
{
    [SerializeField] private Button _offState;
    [SerializeField] private Button _onState;

    private void Start()
    {
        _offState.onClick.AddListener(OnOffButtonClickHandler);
        _onState.onClick.AddListener(OnOnButtonClickHandler);
    }

    private void OnEnable()
    {
        if (SoundManager.Instance.IsMute)
        {
            _offState.gameObject.SetActive(true);
            _onState.gameObject.SetActive(false);
        }
    }

    private void OnOffButtonClickHandler()
    {
        SwitchState();
    }

    private void OnOnButtonClickHandler()
    {
        OnOffButtonClickHandler();
    }

    private void SwitchState()
    {
        SoundManager.Instance.SwitchMuteState();
        _offState.gameObject.SetActive(!_offState.gameObject.activeSelf);
        _onState.gameObject.SetActive(!_onState.gameObject.activeSelf);
    }
}
