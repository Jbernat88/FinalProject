using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public PlayerController PlayerController;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        if(PlayerController.gameOver)
        {
            StartCoroutine(GameOverTimer());
        }
    }

    //Cargamos las escena del juego mediante los botones
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

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


    private IEnumerator GameOverTimer() //Cool Down del disparo
    {
        //PlayerController.gameOver = true;
        yield return new WaitForSeconds(4);
        GameOver();
        
    }
}
