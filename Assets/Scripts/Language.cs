using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLanguage();

    public string CurrentLanguage { get; private set; }

    private void Awake()
    {
        CurrentLanguage = GetLanguage();
    }
}
