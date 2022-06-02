using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;
    public PlayerController PlayerController;

    public float energyLose = 1;

    //Cotxos
    private Vector3 spawnerCar1 = new Vector3(72, 0.5f, -15);
    private Vector3 spawnerCar2 = new Vector3(80, 0.5f, -15);

    public GameObject[] carPrefabs;

    //Platform
    private Vector3 spawnerPlatform1 = new Vector3(0, 40, 15);
    private Vector3 spawnerPlatform2 = new Vector3(0, 40, 5);

    public GameObject platformsPrefabs;

    //Bolla
    private Vector3 spawnerBolla1 = new Vector3(43, 15, -4);
    private Vector3 spawnerBolla2 = new Vector3(57.5f, 15, -4);

    public GameObject bollaPrefabs;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(energyTimer());

        InvokeRepeating("SpawnCar", 2, 3f);

        InvokeRepeating("SpawnCar2", 3, 3f);

        InvokeRepeating("SpawnPlatforms1", 3, 3f);

        InvokeRepeating("SpawnPlatforms2", 3, 3f);

        InvokeRepeating("SpawnBolla1", 3, 3f);

        InvokeRepeating("SpawnBolla2", 2, 3f);


    }

    // Update is called once per frame
    void Update()
    {

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

 

    public void SpawnCar()
    {
        int randomIndex = Random.Range(0, carPrefabs.Length);
        Instantiate(carPrefabs[randomIndex], spawnerCar1, carPrefabs[randomIndex].transform.rotation);
    }

    public void SpawnCar2()
    {
        int randomIndex = Random.Range(0, carPrefabs.Length);
        Instantiate(carPrefabs[randomIndex], spawnerCar2, carPrefabs[randomIndex].transform.rotation);
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

    public void SpawnBolla1()
    {
        //int randomIndex = Random.Range(0, platformsPrefabs.Length);
        Instantiate(bollaPrefabs/*[randomIndex]*/, spawnerBolla1, bollaPrefabs/*[randomIndex]*/.transform.rotation);
    }

    public void SpawnBolla2()
    {
        //int randomIndex = Random.Range(0, platformsPrefabs.Length);
        Instantiate(bollaPrefabs/*[randomIndex]*/, spawnerBolla2, bollaPrefabs/*[randomIndex]*/.transform.rotation);
    }
}