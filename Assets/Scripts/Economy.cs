using System.Collections;
using UnityEngine;

public class Economy : MonoBehaviour
{
    public int Points { get; private set; } = 0;

    [SerializeField] private int _pointsForSecond = 1;

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