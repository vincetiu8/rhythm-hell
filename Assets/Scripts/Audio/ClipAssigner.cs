using System;
using UnityEngine;

namespace Audio
{
    public class ClipAssigner : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponentInChildren<AudioSource>();
            _audioSource.Stop();
        }

        private void Start()
        {
            GameObject empty = GameObject.FindGameObjectWithTag("Song");
            if (empty == null) return;

            _audioSource.clip = empty.GetComponent<AudioSource>().clip;
            Destroy(empty);
            _audioSource.Play();
        }
    }
}