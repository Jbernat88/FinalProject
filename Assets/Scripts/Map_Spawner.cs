using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Spawner : MonoBehaviour
{
   
    //Cotxos
    private Vector3 spawnerCar1 = new Vector3(72, 0.5f, -15);
    private Vector3 spawnerCar2 = new Vector3(80, 0.5f, -15);

    public GameObject[] carPrefabs;

    //Bolla
    private Vector3 spawnerBolla1 = new Vector3(43, 15, -4);
    private Vector3 spawnerBolla2 = new Vector3(57.5f, 15, -4);

    public GameObject bollaPrefabs;




    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("SpawnCar", 2, 3f);

        InvokeRepeating("SpawnCar2", 3, 3f);

        InvokeRepeating("SpawnBolla1", 3, 3f);

        InvokeRepeating("SpawnBolla2", 2, 3f);


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