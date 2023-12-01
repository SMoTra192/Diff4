using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableImage : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(Visible());
    }

    private IEnumerator Visible()
    {
        for (float f = 0.05f; f <= 1.05f; f += 0.05f)
        {
            Color color = sprite.material.color;
            color.a = f;
            sprite.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);
    }
}
