using System.Collections.Generic;
using UnityEngine;

public class GlobalStrings : MonoBehaviour
{
    public Localization _localization;

    [HideInInspector]
    public List<string> _stringsEN = new List<string>()
    {
        "Equip", "Equiped", "Send", "Cancel", "Score"
    };

    [HideInInspector]
    public List<string> _stringsRU = new List<string>()
    {
        "Выбрать", "Выбрано", "Отправить", "Отмена", "Счёт"
    };

    public string GetString(string example)
    {
        int index = _stringsEN.FindIndex(x => x.ToLower() == example.ToLower());

        if (_localization.CurrentLanguage == "ru")
            return _stringsRU[index];
        else
            return _stringsEN[index];
    }
}