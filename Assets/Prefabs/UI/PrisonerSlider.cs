using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrisonerSlider : MonoBehaviour
{
    public Slider mySlider;
    public float decreaseRate = 0.1f;
    public GameObject gameOver;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        DecreaseSliderValue();
    }

    void DecreaseSliderValue()
    {
        mySlider.value -= decreaseRate * Time.deltaTime;
        mySlider.value = Mathf.Clamp(mySlider.value, mySlider.minValue, mySlider.maxValue);

        if(mySlider.value <=0 )
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
