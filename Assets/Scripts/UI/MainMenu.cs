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
        private Button QuitButton;

        private void Start()
        {
            PlayButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Scenes/Level");
            });
            SettingsButton.onClick.AddListener(() =>
            {
                Debug.Log("Settings button");
            });
            QuitButton.onClick.AddListener(() =>
            {
                #if UNITY_EDITOR
                Debug.Log("Quit Button");
                #else
                Application.Quit();
                #endif
            });
        }
    }
}