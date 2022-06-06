using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectCollisions : MonoBehaviour
{
    /*Variables de las particulas
    public ParticleSystem particulas;
    public ParticleSystem wall;
    public ParticleSystem cofres;
    public ParticleSystem player;*/

    

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (gameObject.CompareTag("Proyectil") && otherCollider.gameObject.CompareTag("ground"))
        {
            //Si la bala colisiona con un enemigo se destruyen ambos
            Destroy(gameObject);//Bala
        }
        if (gameObject.CompareTag("Proyectil") && otherCollider.gameObject.CompareTag("Enemy"))
        {
            //Si la bala colisiona con un enemigo se destruyen ambos
            Destroy(gameObject);//Bala
            Destroy(otherCollider.gameObject);
        }

        if(gameObject.CompareTag("Finish1") && otherCollider.gameObject.CompareTag("player"))
        {
            NextLevel();
        }
        if (gameObject.CompareTag("Finish2") && otherCollider.gameObject.CompareTag("player"))
        {
            BossLevel();
        }

        if (gameObject.CompareTag("Attack") && otherCollider.gameObject.CompareTag("ground"))
        {     
            Destroy(gameObject);   
        }
        if (gameObject.CompareTag("Cadira") && otherCollider.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Map_1");
    }
    public void BossLevel()
    {
        SceneManager.LoadScene("FinalBoss");
    }
}
