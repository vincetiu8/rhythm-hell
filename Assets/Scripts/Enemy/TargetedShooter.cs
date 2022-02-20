using System;
using Audio;
using UnityEngine;

namespace Enemy
{
    public class TargetedShooter : AudioSyncer
    {
        private Transform _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        protected Vector2 GetPlayerDirection()
        {
            return _player.position - transform.position;
        }
    }
}