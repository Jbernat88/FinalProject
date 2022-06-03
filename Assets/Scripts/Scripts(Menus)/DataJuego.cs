using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataJuego : MonoBehaviour
{
    public static DataJuego sharedInstance;
    public TextMeshProUGUI Nombre;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AplicarData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AplicarData()
    {
        Nombre.text = DataPersistents.sharedInstance.Nombre;
    }
}
