using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGranny : MonoBehaviour
{
    public Slider HealthSlider;

    public Gradient gradient;
    public Image fill;

    private void Awake()
    {
        
    }

    public void SetHealth(float health)
    {
        HealthSlider.value = health;
        fill.color = gradient.Evaluate(HealthSlider.normalizedValue);
    }

}

