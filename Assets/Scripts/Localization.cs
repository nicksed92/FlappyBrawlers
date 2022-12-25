using System.Runtime.InteropServices;
using UnityEngine;

public class Localization : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLanguage();

    public string CurrentLanguage { get; private set; } = "en";

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            CurrentLanguage = GetLanguage();
/*        if (PlayerPrefs.HasKey("CurrentLanguage") == false)
        {
            PlayerPrefs.SetString("CurrentLanguage", CurrentLanguage);
        }
        else
        {
            CurrentLanguage = PlayerPrefs.GetString("CurrentLanguage");
        }*/
#endif
    }
}