using System;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSpectrum : MonoBehaviour
    {
        public static Dictionary<FFTWindow, float> SpectrumValues;

        private float[] _audioSpectrum;

        private void Awake()
        {
            SpectrumValues = new Dictionary<FFTWindow, float>();
            _audioSpectrum = new float[128];
        }

        private void Update()
        {
            foreach (FFTWindow fftWindow in Enum.GetValues(typeof(FFTWindow)))
            {
                AudioListener.GetSpectrumData(_audioSpectrum, 0, fftWindow);

                if (_audioSpectrum != null && _audioSpectrum.Length > 0)
                {
                    SpectrumValues[fftWindow] = _audioSpectrum[0] * 100;
                }
            }

        }
    }
}