using System;
using UnityEngine;

namespace Audio
{
    public class AudioSyncSpawner : AudioSyncer
    {
        [SerializeField] private GameObject objectPrefab;

        protected override void OnBeat(int beatPower)
        {
            GameObject objectInstance = Instantiate(objectPrefab, transform.position, transform.rotation);
        }
    }
}