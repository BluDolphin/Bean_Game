using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    //set slider value to the maximum amount of health
    public void SetMaximum(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //set sliders current value to health
    public void SetSlider(int health)
    {
        slider.value = health;
    }
}