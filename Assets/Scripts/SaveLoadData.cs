using System.Collections.Generic;
using UnityEngine;

public class SaveLoadData : MonoBehaviour
{
    private const string SkinsKey = "skin";
    private const string EquipedSkin = "equiped_skin";

    public enum SaveType
    {
        Skins,
        EquipedSkin
    }

    public static void SaveList(List<int> list, SaveType type)
    {
        string key = SetType(type);

        for (int i = 0; i < list.Count; i++)
        {
            PlayerPrefs.SetInt(key + i, list[i]);
        }
    }

    public static List<int> LoadList(SaveType type)
    {
        string key = SetType(type);
        List<int> result = new List<int>() { 0 };

        for (int i = 1; i < int.MaxValue; i++)
        {
            if (PlayerPrefs.HasKey(key + i))
                result.Add(PlayerPrefs.GetInt(key + i));
            else
                break;
        }

        return result;
    }

    public static void SaveInt(int value, SaveType type)
    {
        string key = SetType(type);
        PlayerPrefs.SetInt(key, value);
    }

    public static int LoadInt(SaveType type)
    {
        int result = 0;

        string key = SetType(type);

        if (PlayerPrefs.HasKey(key))
            result = PlayerPrefs.GetInt(key);

        return result;
    }

    private static string SetType(SaveType type)
    {
        string result = string.Empty;

        switch (type)
        {
            case SaveType.Skins:
                result = SkinsKey;
                break;

            case SaveType.EquipedSkin:
                result = EquipedSkin;
                break;
        }

        return result;
    }
}
