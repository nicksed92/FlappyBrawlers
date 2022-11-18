using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ScrollMaterial : MonoBehaviour
{
    private bool isScrolling = true;

    private enum ScrollOrientation
    {
        Horizontale,
        Vertical
    }

    [SerializeField] private float _scrollSpeed;
    [SerializeField] private ScrollOrientation _scrollOrientation = ScrollOrientation.Horizontale;

    private Material _material;

    private void Awake()
    {
        GlobalEvents.OnPlayerHit.AddListener(StopScrolling);
    }

    private void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }
    private void FixedUpdate()
    {
        if (isScrolling)
            SetTextureOffset();
    }

    private void StopScrolling(int score)
    {
        isScrolling = false;
    }

    private void SetTextureOffset()
    {
        switch (_scrollOrientation)
        {
            case ScrollOrientation.Vertical:
                _material.SetTextureOffset("_MainTex", new Vector2(1f, _material.GetTextureOffset("_MainTex").y + _scrollSpeed * Time.deltaTime));
                break;
            default:
                _material.SetTextureOffset("_MainTex", new Vector2(_material.GetTextureOffset("_MainTex").x + _scrollSpeed * Time.deltaTime, 1f));
                break;
        }
    }
}