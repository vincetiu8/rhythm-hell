using System;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSpectrum : MonoBehaviour
    {
        [HideInInspector] public float spectrumValue;

        [SerializeField] private FFTWindow _fftWindow;

        private float[] _audioSpectrum;

        private void Awake()
        {
            _audioSpectrum = new float[128];
        }

        private void Update()
        {
            AudioListener.GetSpectrumData(_audioSpectrum, 0, _fftWindow);

            if (_audioSpectrum != null && _audioSpectrum.Length > 0)
            {
                spectrumValue = _audioSpectrum[0] * 100;
            }
        }
    }
}