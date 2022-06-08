using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistents : MonoBehaviour
{
    public static DataPersistents sharedInstance;

    public string Nombre;
    public int Score;

    public string HighNombre;
    public int HighScore;

    public int level2;
    public int level3;

    public DetectCollisions DetectCollision;

    

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(sharedInstance);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {

    }

    public void Data()
    {
        PlayerPrefs.SetString("NOMBRE", Nombre);
        PlayerPrefs.SetInt("SCORE", Score);
        PlayerPrefs.SetString("HIGHNOMBRE", HighNombre);
        PlayerPrefs.SetInt("HIGHSCORE", HighScore);

        PlayerPrefs.SetInt("NIVEL2", level2);
        PlayerPrefs.SetInt("NIVEL3", level3);

    }
}
