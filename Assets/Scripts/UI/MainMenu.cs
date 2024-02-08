﻿using UnityEngine;
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
        [SerializeField]
        private Button options;
        [SerializeField]
        private Button back;
        public GameObject optionsMenu;
        public GameObject compass;

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
               SceneManager.LoadScene("MainMenu");
            });



            options.onClick.AddListener(() =>
            {
                optionsMenu.SetActive(true);
                compass.SetActive(false);
                Time.timeScale = 0;
            });


            back.onClick.AddListener(() =>
            {
               optionsMenu.SetActive(false);
               compass.SetActive(true);

                Time.timeScale = 1;
            });
        }
    }
}