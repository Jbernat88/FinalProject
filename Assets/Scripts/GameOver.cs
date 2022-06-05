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


    }

    public void isGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


    private IEnumerator GameOverTimer() //Cool Down del disparo
    {
        //PlayerController.gameOver = true;
        yield return new WaitForSeconds(4);
        isGameOver();

    }
}
