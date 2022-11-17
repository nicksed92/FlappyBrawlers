using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Points { get; private set; } = 0;
    public List<int> UnlockedSkinsID { get; } = new() { 0, 1, 2, 3 };
    public int EquipedSkinID { get; set; } = 1;

    [SerializeField] private int _pointsForSecond = 1;

    public void AddUnlockedSkin()
    {
        UnlockedSkinsID.Add(UnlockedSkinsID.Count);
    }

    private void Start()
    {
        StartCoroutine(AddPoints());
    }

    private IEnumerator AddPoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Points += _pointsForSecond;
            GlobalEvents.OnPointsChanged?.Invoke(Points);
        }
    }
}
