using System;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    [SerializeField] Material sky;
    [SerializeField] Material grass;
    [SerializeField] Material ground;

    [Range(0.01f, 0.1f)]
    [SerializeField] float skySpeed = 0.1f;

    [Range(0.01f, 0.2f)]
    [SerializeField] float grassSpeed = 0.2f;

    [Range(0.01f, 0.5f)]
    [SerializeField] float groundSpeed = 0.3f;

    private void FixedUpdate()
    {
        sky.SetTextureOffset("_MainTex", new Vector2(sky.GetTextureOffset("_MainTex").x + skySpeed * Time.deltaTime, 1f));
        grass.SetTextureOffset("_MainTex", new Vector2(grass.GetTextureOffset("_MainTex").x + grassSpeed * Time.deltaTime, 1f));
        ground.SetTextureOffset("_MainTex", new Vector2(ground.GetTextureOffset("_MainTex").x + groundSpeed * Time.deltaTime, 1f));
    }
}