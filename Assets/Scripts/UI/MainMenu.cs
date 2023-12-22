using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private Button PlayButton;
        [SerializeField]
        private Button QuitButton;
        [SerializeField]
        private Button SettingsButton;

        private void Start()
        {
            PlayButton.onClick.AddListener(() =>
            {
                Debug.Log("Play Button");
            });
            SettingsButton.onClick.AddListener(() =>
            {
                Debug.Log("Settings button");
            });
            QuitButton.onClick.AddListener(() =>
            {
                Debug.Log("Quit Button");
            });
        }
    }
}