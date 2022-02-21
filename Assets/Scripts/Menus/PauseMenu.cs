using System;
using Audio;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class PauseMenu : MenuManager
    {
        [SerializeField] private AudioSpectrum audioSpectrum;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject pauseMenu;
        
        private PlayerInput _playerInput;

        protected override void Awake()
        {
            
        }
        
        private void Start()
        {
            _playerInput = player.GetComponent<PlayerInput>();
            _playerInput.SwitchCurrentActionMap("Player");
            pauseMenu.SetActive(false);
        }

        public void TogglePause(bool pause)
        {
            _playerInput.SwitchCurrentActionMap(pause ? "UI" : "Player");
            if (pause)
            {
                if (CurrentMenu != null) return;
                
                pauseMenu.SetActive(true);
                CurrentMenu = pauseMenu;
                return;
            }
            
            CurrentMenu.SetActive(false);
        }
        
        public void OnExit()
        {
            SceneManager.LoadSceneAsync("Start");
        }
    }
}
