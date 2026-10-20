using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class S_rockSprite : MonoBehaviour
{
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.sprite = spriteList[UnityEngine.Random.Range(0, spriteList.Count-1)];
        int rand = UnityEngine.Random.Range(0, 1);
        if(rand == 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(rand == 1)
        {
                spriteRenderer.flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
