using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPopupController : MonoBehaviour
{
    [SerializeField] private float lifetime;

    private float _duration;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        _duration = lifetime;
        while (_duration > 0)
        {
            _text.alpha = _duration / lifetime;
            _duration -= Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

    public void Setup(int change)
    {
        if (change > 0)
        {
            _text.text = $"+{change}";
            _text.color = Color.green;
            return;
        }

        _text.text = change.ToString();
        _text.color = Color.red;
    }
}