using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    [SerializeField] float fadeDuration = 2f;

    private SpriteRenderer renderer;

    [SerializeField] private bool toggleFadeOut = true;
    

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleFadeOut)
        {
            StartCoroutine(fadeOut());
        }
        else
        {
            StartCoroutine(fadeIn());
        }

    }

    IEnumerator fadeOut()
    {
        float time = 0.0f;

        while (time <= fadeDuration)
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, time / fadeDuration);

            Color newColor = renderer.color;
            newColor.a = alpha;
            renderer.color = newColor;

            time += Time.deltaTime;
            yield return null;
        }
    }
    
    IEnumerator fadeIn()
    {
        float time = 0.0f;
       // gameObject.SetActive(true);

        while (time <= fadeDuration)
        {
            float alpha = Mathf.Lerp(0.0f, 1.0f, time / fadeDuration);

            Color newColor = renderer.color;
            newColor.a = alpha;
            renderer.color = newColor;

            time += Time.deltaTime;
            yield return null;
        }

        
    }
}
