using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Menus
{
    public class OptionsMenuController : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private TMP_Dropdown resolutionDropdown;
        [SerializeField] private TMP_Dropdown fullScreenModeDropdown;
        [SerializeField] private Slider volumeSlider;
        
        
        private void Start()
        {
            resolutionDropdown.options.Clear();
            foreach (Resolution resolution in Screen.resolutions)
            {
                resolutionDropdown.options.Add(
                    new TMP_Dropdown.OptionData($"{resolution.width} x {resolution.height}"));
                if (resolution.width == Screen.currentResolution.width &&
                    resolution.height == Screen.currentResolution.height)
                {
                    resolutionDropdown.onValueChanged.Invoke(resolutionDropdown.options.Count - 1);
                }
            }
            resolutionDropdown.RefreshShownValue();

            fullScreenModeDropdown.options.Clear();
            foreach (FullScreenMode fullScreenMode in Enum.GetValues(typeof(FullScreenMode)))
            {
                fullScreenModeDropdown.options.Add(new TMP_Dropdown.OptionData(fullScreenMode.ToString()));
                if (fullScreenMode == Screen.fullScreenMode)
                {
                    fullScreenModeDropdown.onValueChanged.Invoke(fullScreenModeDropdown.options.Count - 1);
                }
            }
            fullScreenModeDropdown.RefreshShownValue();

            audioMixer.GetFloat("MasterVolume", out float volume);
            volumeSlider.value = Mathf.Pow(10, volume) * 20;
        }

        public void SetResolution(int index)
        {
            Screen.SetResolution(Screen.resolutions[index].width, Screen.resolutions[index].height,
                Screen.fullScreenMode);
        }

        public void SetFullScreenMode(int index)
        {
            FullScreenMode fullScreenMode = (FullScreenMode) Enum.GetValues(typeof(FullScreenMode)).GetValue(index);
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, fullScreenMode);
        }

        public void SetVolume(float value)
        {
            if (value == 0)
            {
                audioMixer.SetFloat("MasterVolume", -1000);
                return;
            }
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
        }
    }
}