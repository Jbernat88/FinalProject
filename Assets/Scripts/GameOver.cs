using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{

    public PlayerController PlayerController;

    //private bool isGameOver;

    void Update()
    {

        if (PlayerController.gameOver)
        {
            StartCoroutine(GameOverTimer());
        }

        if (PlayerController.gameWon)
        {
            StartCoroutine(GameWonTimer());
        }


    }

    public void isGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void isGameWon()
    {
        SceneManager.LoadScene("WIN");
    }


    private IEnumerator GameOverTimer() //Cool Down del disparo
    {
        //PlayerController.gameOver = true;
        yield return new WaitForSeconds(4);
        isGameOver();

    }

    private IEnumerator GameWonTimer() //Cool Down del disparo
    {
        //PlayerController.gameOver = true;
        yield return new WaitForSeconds(4);
        isGameWon();

    }
}
