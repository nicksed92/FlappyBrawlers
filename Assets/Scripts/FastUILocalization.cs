using UnityEngine;

public class FastUILocalization : MonoBehaviour
{
    [SerializeField] private string EN;

    private void Start()
    {
        GlobalStrings globalStrings = FindObjectOfType<GlobalStrings>();
        globalStrings.GetString(EN);
    }
}