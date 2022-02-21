using System;
using UnityEngine;

namespace Menus
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject initialMenu;

        protected GameObject CurrentMenu;

        protected virtual void Awake()
        {
            if (initialMenu == null)
            {
                Debug.LogError("No default menu set on open");
            }

            CurrentMenu = initialMenu;
            CurrentMenu.SetActive(true);
        }

        public void OpenMenu(GameObject menu)
        {
            if (CurrentMenu != null)
            {
                CurrentMenu.SetActive(false);
            }

            CurrentMenu = menu;
            CurrentMenu.SetActive(true);
        }
    }
}