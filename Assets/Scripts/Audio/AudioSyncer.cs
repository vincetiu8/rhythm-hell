using System;
using UnityEngine;

namespace Audio
{
    public class AudioSyncer : MonoBehaviour
    {
        public float bias;
        public float timeStep;
        public float timeToBeat;
        public float restSmoothTime;

        protected bool IsBeat;

        private float _previousAudioValue;
        private float _audioValue;
        private float _timer;

        protected virtual void Update()
        {
            _previousAudioValue = _audioValue;
            _audioValue = AudioSpectrum.SpectrumValue;
            if (_previousAudioValue > bias != _audioValue > bias)
            {
                if (_timer > timeStep)
                {
                    OnBeat();
                }
            }

            _timer += Time.deltaTime;
        }

        public virtual void OnBeat()
        {
            Debug.Log("Beat");
            _timer = 0;
            IsBeat = true;
        }
    }
}