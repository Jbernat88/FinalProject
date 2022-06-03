using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MenuNombre : MonoBehaviour
{
    public TMP_InputField NombreUsuario;

    // Start is called before the first frame update
    void Start()
    {
        LoadUserOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Si no escribes el nombre de usuario, el juego no podra empezar
    public void Empezar()
    {
        if (string.IsNullOrEmpty (NombreUsuario.text))
        {
            
        }
        else
        {
            SceneManager.LoadScene("MenuOpciones");
            DataPersistents.sharedInstance.Nombre = NombreUsuario.text;
        }
    }

    public void LoadUserOptions()
    {
        NombreUsuario.text = PlayerPrefs.GetString("NOMBRE");

       
    }

}
