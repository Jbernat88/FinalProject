using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene("Map_1");
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
