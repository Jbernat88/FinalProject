using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public bool unlockLevel2;
    public bool unlockLevel3;

    //Cargamos las escena del juego mediante los botones
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Map_2");

    }

    public void EscenaJuego2()
    {
        if(unlockLevel2)
        { 
            SceneManager.LoadScene("Map_1");
        }
 
    }
    public void EscenaJuego3()
    {
        if(unlockLevel3)
        {
            SceneManager.LoadScene("FinalBoss");
        }
        
    }
    public void EscenaScore()
    {
        SceneManager.LoadScene("Score");
    }

    public void EscenaComoJugar()
    {
        SceneManager.LoadScene("ComoJugar");
    }

    public void EscenaMenuOpciones()
    {
        SceneManager.LoadScene("MenuOpciones");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Me voy");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
