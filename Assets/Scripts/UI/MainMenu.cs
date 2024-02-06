using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private Button PlayButton;
        [SerializeField]
        private Button SettingsButton;
        [SerializeField]
        private Button MenuButton;

        private void Start()
        {
            PlayButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Level");
            });
            SettingsButton.onClick.AddListener(() =>
            {
                Debug.Log("Settings button");
            });
            MenuButton.onClick.AddListener(() =>
            {
                #if UNITY_EDITOR
                Debug.Log("MainMenu");
                #else
                Application.Quit();
                #endif
            });
        }
    }
}