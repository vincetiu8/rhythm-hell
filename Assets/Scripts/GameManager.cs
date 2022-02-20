using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int countdownTime;
    [SerializeField] private TMP_Text countdownText;

    private ShooterController[] _shooterControllers;
    private AudioSource _audioSource;

    private void Awake()
    {
        _shooterControllers = GetComponentsInChildren<ShooterController>();
        ToggleSpawners(false);

        _audioSource = GetComponentInChildren<AudioSource>();
        _audioSource.Stop();
    }

    private void Start()
    {
        GameObject empty = GameObject.FindGameObjectWithTag("Song");
        _audioSource.clip = empty.GetComponent<AudioSource>().clip;
        Destroy(empty);
        StartCoroutine(Countdown());

        foreach (Transform child in transform)
        {
            if (child.CompareTag("Spawner"))
            {
                child.position = new Vector3(0, Camera.main.orthographicSize);
            }
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
    }

    private void ToggleSpawners(bool toggle)
    {
        foreach (ShooterController controller in _shooterControllers)
        {
            controller.gameObject.SetActive(toggle);
        }
    }
}