using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryHandler : MonoBehaviour
{
    public GameObject story;
    public GameObject backgroundPanel;
    public List<GameObject> uiItems = new List<GameObject>();

    private void Start()
    {
        Time.timeScale = 0;

        foreach (GameObject item in uiItems)
        {
            item.SetActive(false);
        }
    }

  

    public void ExitStory()
    {
        Time.timeScale = 1;
        story.SetActive(false);
        uiItems[0].SetActive(true);
        backgroundPanel.SetActive(false);

        foreach (GameObject item in uiItems)
        {
            item.SetActive(true);
        }
    }
}
