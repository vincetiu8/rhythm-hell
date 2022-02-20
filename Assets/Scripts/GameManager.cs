using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Enemy;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int countdownTime;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject winPrefab;
    [SerializeField] private Text winText;
    [SerializeField] private GameObject playerPrefab;

    private ShooterController[] _shooterControllers;
    private AudioSource _audioSource;
    private Vector2 _cameraDimensions;
    private bool _songStarted = false;

    private void Awake()
    {
        _shooterControllers = GetComponentsInChildren<ShooterController>();
        ToggleSpawners(false);

        _audioSource = GetComponentInChildren<AudioSource>();
        _audioSource.Stop();

        _cameraDimensions =
            new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
        GameObject child = new GameObject
        {
            transform =
            {
                parent = transform
            },
            layer = LayerMask.NameToLayer("Bullets")
        };
        BoxCollider2D box = child.AddComponent<BoxCollider2D>();
        box.size = new Vector2((_cameraDimensions.x + 1) * 2, 1);
        box.offset = new Vector2(0, _cameraDimensions.y + 0.5f);
        box = gameObject.AddComponent<BoxCollider2D>();
        box.size = new Vector2((_cameraDimensions.x + 1) * 2, 1);
        box.offset = new Vector2(0, - _cameraDimensions.y - 0.5f);
        box= gameObject.AddComponent<BoxCollider2D>();
        box.size = new Vector2(1, (_cameraDimensions.y + 1) * 2);
        box.offset = new Vector2(_cameraDimensions.x + 0.5f, 0);
        box = gameObject.AddComponent<BoxCollider2D>();
        box.size = new Vector2(1, (_cameraDimensions.y + 1) * 2);
        box.offset = new Vector2(-_cameraDimensions.x - 0.5f, 0);
        Debug.Break();
    }

    private void Start()
    {
        GameObject empty = GameObject.FindGameObjectWithTag("Song");
        if (empty != null)
        {
            _audioSource.clip = empty.GetComponent<AudioSource>().clip;
            Destroy(empty);
        }

        StartCoroutine(Countdown());

        foreach (Transform child in transform)
        {
            if (child.CompareTag("Spawner"))
            {
                child.position = new Vector3(0, _cameraDimensions.y);
            }
        }
    }

    private void Update()
    {
        if (!_audioSource.isPlaying && _songStarted)
        {
            winPrefab.SetActive(true);
            Counter.CounterInstance.StopIncrement();
            winText.text = Counter.CounterInstance.GetTime().ToString();
            Destroy(playerPrefab);
        }
    }

    private IEnumerator Countdown()
    {
        float timer = countdownTime;

        while (timer > 0)
        {
            countdownText.text = ((int)timer + 1).ToString();
            timer -= Time.deltaTime;
            yield return null;
        }
        
        countdownText.gameObject.SetActive(false);
        ToggleSpawners(true);
        _audioSource.Play();
        _songStarted = true;
    }

    private void ToggleSpawners(bool toggle)
    {
        foreach (ShooterController controller in _shooterControllers)
        {
            controller.gameObject.SetActive(toggle);
        }
    }
}