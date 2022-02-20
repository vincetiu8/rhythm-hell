using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class StartMenuController : MonoBehaviour
    {
        public void OpenGame()
        {
            SceneManager.LoadSceneAsync("Main");
        }
    }
}
