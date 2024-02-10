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
        private Button MenuButton;
        [SerializeField]
        private Button OptionsMenu;
        [SerializeField]
        private Button BackButton;
        [SerializeField]
        private GameObject OptionsPanel;

        private void Start()
        {
            PlayButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Level");
            });

            MenuButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("MainMenu");
            });

            OptionsMenu.onClick.AddListener(() =>
            {
                OptionsPanel.SetActive(true);
            });

            BackButton.onClick.AddListener(() =>
            {
                OptionsPanel.SetActive(false);
            });



        }
    }
}