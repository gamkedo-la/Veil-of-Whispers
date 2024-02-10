using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
  public GameObject OptionsPanel;
  public GameObject Compass;

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

    public void BackFromMenu()
  {
      SceneManager.LoadScene("MainMenu");
  }




}
