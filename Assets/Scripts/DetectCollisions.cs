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

    public ParticleSystem proyectil;

    public bool isLevel2;
    public bool isLevel3;

    public int level2;
    public int level3;

    private SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
        void Update()
    {
        if (isLevel2)
        {
            level2 = 1;
        }
        else
        {
            level2 = 0;
        }

        if (isLevel3)
        {
            level3 = 1;
        }
        else
        {
            level3 = 0;
        }
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (gameObject.CompareTag("Proyectil") && otherCollider.gameObject.CompareTag("ground"))
        {
            proyectil = Instantiate(proyectil, transform.position, proyectil.transform.rotation);
            proyectil.Play();
            Destroy(gameObject);//Bala
        }
        if (gameObject.CompareTag("Proyectil") && otherCollider.gameObject.CompareTag("Enemy"))
        {
            proyectil = Instantiate(proyectil, transform.position, proyectil.transform.rotation);
            proyectil.Play();
            soundManager.SeleccionAudio(6, 1f);
            //Si la bala colisiona con un enemigo se destruyen ambos
            Destroy(gameObject);//Bala
            Destroy(otherCollider.gameObject);
        }

        if (gameObject.CompareTag("Proyectil") && otherCollider.gameObject.CompareTag("Enemy2"))
        {
            proyectil = Instantiate(proyectil, transform.position, proyectil.transform.rotation);
            proyectil.Play();
            soundManager.SeleccionAudio(5, 1f);
            //Si la bala colisiona con un enemigo se destruyen ambos
            Destroy(gameObject);//Bala
            Destroy(otherCollider.gameObject);
        }

        if (gameObject.CompareTag("Proyectil") && otherCollider.gameObject.CompareTag("Boss"))
        {
            proyectil = Instantiate(proyectil, transform.position, proyectil.transform.rotation);
            proyectil.Play();
            //Si la bala colisiona con un enemigo se destruyen ambos
            Destroy(gameObject);//Bala
            
        }

        if (gameObject.CompareTag("Finish1") && otherCollider.gameObject.CompareTag("player"))
        {
            isLevel2 = true;
            NextLevel();
        }
        if (gameObject.CompareTag("Finish2") && otherCollider.gameObject.CompareTag("player"))
        {
            isLevel3 = true;
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
        SceneManager.LoadScene("Score");
    }
    public void BossLevel()
    {
        SceneManager.LoadScene("Score");
    }


    public void LoadUserOptions()
    {
        level2 = PlayerPrefs.GetInt("LEVEL2");


    }
}
