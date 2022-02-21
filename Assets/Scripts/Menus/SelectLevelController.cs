using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelController : MonoBehaviour
{
    [SerializeField] private AudioClip[] songs;
    [SerializeField] private TMP_Text songText;

    private int _currentSong;

    private void OnEnable()
    {
        _currentSong = 0;
        songText.text = songs[0].name;
    }

    private void ChangeSong(int change)
    {
        _currentSong = (_currentSong + change + songs.Length) % songs.Length;
        songText.text = songs[_currentSong].name;
    }

    public void NextSong()
    {
        ChangeSong(1);
    }

    public void PrevSong()
    {
        ChangeSong(-1);
    }

    public void OnPlay()
    {
        GameObject empty = GameObject.CreatePrimitive(PrimitiveType.Cube);
        empty.tag = "Song";
        AudioSource source = empty.AddComponent<AudioSource>();
        source.Stop();
        source.clip = songs[_currentSong];
        DontDestroyOnLoad(empty);
        SceneManager.LoadSceneAsync("Main");
    }

    public void OnVisualize()
    {
        GameObject empty = GameObject.CreatePrimitive(PrimitiveType.Cube);
        empty.tag = "Song";
        AudioSource source = empty.AddComponent<AudioSource>();
        source.Stop();
        source.clip = songs[_currentSong];
        DontDestroyOnLoad(empty);
        SceneManager.LoadSceneAsync("Audio Testing");
    }
}