using System;
using UnityEngine;

namespace Menus
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject initialMenu;

        private GameObject _currentMenu;

        private void Awake()
        {
            if (initialMenu == null)
            {
                Debug.LogError("No default menu set on open");
            }

            _currentMenu = initialMenu;
            _currentMenu.SetActive(true);
        }

        public void OpenMenu(GameObject menu)
        {
            _currentMenu.SetActive(false);
            _currentMenu = menu;
            _currentMenu.SetActive(true);
        }
    }
}
