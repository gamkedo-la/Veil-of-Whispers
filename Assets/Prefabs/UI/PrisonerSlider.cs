using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrisonerSlider : MonoBehaviour
{
    public Slider mySlider;
    public float decreaseRate = 0.1f; 

    void Start()
    {
        mySlider.value = 1f;
    }

    void Update()
    {
        DecreaseSliderValue();
    }

    void DecreaseSliderValue()
    {
        mySlider.value -= decreaseRate * Time.deltaTime;
        mySlider.value = Mathf.Clamp(mySlider.value, mySlider.minValue, mySlider.maxValue);
    }
}
