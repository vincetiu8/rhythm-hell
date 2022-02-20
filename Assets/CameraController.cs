using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Color color1, color2;
    [SerializeField] private float changeSpeed;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        DontDestroyOnLoad(gameObject);
    }

    private void LateUpdate()
    {
        _camera.backgroundColor = Color.Lerp(color1, color2, Mathf.Sin(Time.time * changeSpeed));
    }
}
