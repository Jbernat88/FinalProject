using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public HealthBar healthBar;
    public PlayerController PlayerController;

    public float energyLose = 1;

    

    //Platform
    private Vector3 spawnerPlatform1 = new Vector3(-23, 40, 0);
    private Vector3 spawnerPlatform2 = new Vector3(-9, 40, 0);
    private Vector3 spawnerPlatform3 = new Vector3(-16, -10, 0);

    public GameObject platformsPrefabs;
    public GameObject platformsPrefabsMiddle;

    void Start()
    {
        StartCoroutine(energyTimer());

        InvokeRepeating("SpawnPlatforms1", 3, 6f);

        InvokeRepeating("SpawnPlatforms2", 3, 6f);

        InvokeRepeating("SpawnPlatforms3", 3, 3f);

    }

    public IEnumerator energyTimer()
    {
        Debug.Log(healthBar.HealthSlider.value);
        while (healthBar.HealthSlider.value > 0)
        {
            yield return new WaitForSeconds(1);
            healthBar.HealthSlider.value -= energyLose;
            PlayerController.currentHealth -= energyLose;

        }

    }

 
    public void SpawnPlatforms1()
    {
        //int randomIndex = Random.Range(0, platformsPrefabs.Length);
        Instantiate(platformsPrefabs/*[randomIndex]*/, spawnerPlatform1, platformsPrefabs/*[randomIndex]*/.transform.rotation);
    }

    public void SpawnPlatforms2()
    {
        //int randomIndex = Random.Range(0, platformsPrefabs.Length);
        Instantiate(platformsPrefabs/*[randomIndex]*/, spawnerPlatform2, platformsPrefabs/*[randomIndex]*/.transform.rotation);
    }

    public void SpawnPlatforms3()
    {
        //int randomIndex = Random.Range(0, platformsPrefabs.Length);
        Instantiate(platformsPrefabsMiddle/*[randomIndex]*/, spawnerPlatform3, platformsPrefabsMiddle/*[randomIndex]*/.transform.rotation);
    }

}