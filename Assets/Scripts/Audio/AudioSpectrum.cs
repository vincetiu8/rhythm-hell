using System;
using UnityEngine;

namespace Audio
{
    public class AudioSpectrum : MonoBehaviour
    {
        public static float SpectrumValue;

        private float[] _audioSpectrum;

        private void Awake()
        {
            _audioSpectrum = new float[128];
        }

        private void Update()
        {
            AudioListener.GetSpectrumData(_audioSpectrum, 0, FFTWindow.Hamming);

            if (_audioSpectrum != null && _audioSpectrum.Length > 0)
            {
                SpectrumValue = _audioSpectrum[0] * 100;
            }
        }
    }
}
