using System;
using UnityEngine;

namespace Audio
{
    public abstract class AudioSyncer : MonoBehaviour
    {
        private readonly float[] _biasIntervals = { 25f, 35f, 45f, 55f, 65f, 75f };
        private const float TimeBetweenBeats = 0.05f;

        [SerializeField] private FFTWindow fftWindow;

        private float _previousAudioValue;
        private float _audioValue;
        private float _timer;

        protected virtual void Update()
        {
            _previousAudioValue = _audioValue;
            _audioValue = AudioSpectrum.SpectrumValues[fftWindow];

            CheckBeat();

            _timer += Time.deltaTime;
        }

        private void CheckBeat()
        {
            if (_timer < TimeBetweenBeats) return;

            int i;
            for (i = 0; i < _biasIntervals.Length; i++)
            {
                float bias = _biasIntervals[i];
                if (_previousAudioValue > bias == _audioValue > bias)
                {
                    break;
                }
            }
            
            if (i == 0) return;
            
            OnBeat(i - 1);
            _timer = 0;
        }

        protected abstract void OnBeat(int beatPower);
    }
}