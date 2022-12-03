using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
#if UNITY_EDITOR == false && UNITY_WEBGL == true
    [DllImport("__Internal")]
    private static extern string GetLanguage();

    public string CurrentLanguage { get; private set; }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("CurrentLanguage") == false)
        {
            CurrentLanguage = GetLanguage();
            PlayerPrefs.SetString("CurrentLanguage", CurrentLanguage);
        }
        else
        {
            CurrentLanguage = PlayerPrefs.GetString("CurrentLanguage");
        }
    }
#endif
}
