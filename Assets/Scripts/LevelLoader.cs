using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
  public GameObject OptionsPanel;
  public GameObject Compass;
  public GameObject startButton;
  private StoryHandler StoryHandler;

  private void Start()
  {
     StoryHandler = FindObjectOfType<StoryHandler>();
  }

    public void MainMenuScene()
  {
       SceneManager.LoadScene("MainMenu");
  }

  public void LevelScene()
  {
       SceneManager.LoadScene("Level");
  }

  public void Credits()
  {
      SceneManager.LoadScene("Credits");
  }


  public void Options()
  {
     OptionsPanel.SetActive(true);
     Compass.SetActive(false);
  }

   
  public void BackFromOptions()
  {
    OptionsPanel.SetActive(false);
    Compass.SetActive(true);
  }

  public void GameBegins()
  {
      StoryHandler.ExitStory();
      startButton.SetActive(false);
  }

  public void BackFromMenu()
  {
      SceneManager.LoadScene("MainMenu");
  }




}
