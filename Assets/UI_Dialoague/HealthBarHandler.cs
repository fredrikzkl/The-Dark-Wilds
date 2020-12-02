using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarHandler : MonoBehaviour
{
    public Slider slider;

    void SetMaxHeath()
    {
        slider.value = slider.maxValue;
    }

    void SetHealth(int health)
    {
        slider.value = health;
    }
}
