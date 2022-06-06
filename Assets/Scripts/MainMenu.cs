using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    //Cargamos las escena del juego mediante los botones
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Map_2");

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
