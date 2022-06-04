using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;
    public PlayerController PlayerController;

    public float energyLose = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(energyTimer());

    }

    public IEnumerator energyTimer()
    {
        Debug.Log(healthBar.HealthSlider.value);
        while (healthBar.HealthSlider.value > 0)
        {
            yield return new WaitForSeconds(0.4f);
            healthBar.HealthSlider.value -= energyLose;
            PlayerController.currentHealth -= energyLose;

        }

    }
}