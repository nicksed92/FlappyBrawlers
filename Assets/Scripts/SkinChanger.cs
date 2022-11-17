using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private float _startScrollPositionX;
    [SerializeField] private GameObject _skinTemplate;
    [SerializeField] private Transform _conteiner;
    [SerializeField] private Sprite[] _skins;

    private RectTransform _rectTransform;
    private Image _image;
    private Button _button;
    private Text _buttonText;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        for (int i = 0; i < _skins.Length; i++)
        {
            GameObject template = Instantiate(_skinTemplate, _conteiner);
            _image = template.transform.GetChild(0).GetComponent<Image>();
            _image.sprite = _skins[i];
            _image.color = Color.black;
            //_button = template.transform.GetChild(1).GetComponent<Button>();
        }

        _rectTransform.anchoredPosition = new Vector3(_startScrollPositionX, 0, 0);
    }
}