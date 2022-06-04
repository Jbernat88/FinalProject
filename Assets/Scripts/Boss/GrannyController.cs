using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyController : MonoBehaviour
{

    //Player
    public PlayerController PlayerController;

    //Vida 
    public int maxHealth = 150;
    public float currentHealth;
    public HealthGranny healthGranny;

    //Disparo
    public GameObject xancla;
    public bool isCoolDownAttack1 = true;
    private float CoolDownAttack1 = 3;
    public GameObject ShotPivot;

    public bool isCoolDownAttack2 = true;
    private float CoolDownAttack2 = 5;
    public GameObject ShotPivot2;
    public GameObject ShotPivot3;
    public GameObject ShotPivot4;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 50;
        isCoolDownAttack1 = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isCoolDownAttack1 && !PlayerController.gameOver)
        {
            Instantiate(xancla, ShotPivot.transform.position, transform.rotation);

            StartCoroutine(TimerAttack1());
            isCoolDownAttack1 = false;
        }

        if (isCoolDownAttack2 && !PlayerController.gameOver)
        {
            Instantiate(xancla, ShotPivot2.transform.position, ShotPivot2.transform.rotation);
            Instantiate(xancla, ShotPivot3.transform.position, ShotPivot3.transform.rotation);
            Instantiate(xancla, ShotPivot4.transform.position, ShotPivot4.transform.rotation);
            StartCoroutine(TimerAttack2());
            isCoolDownAttack1 = false;
        }
    }


    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Proyectil"))
        {
            TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthGranny.SetHealth(currentHealth);
    }

    void HealDamage(int damage)
    {
        currentHealth += damage;
        healthGranny.SetHealth(currentHealth);
    }

    private IEnumerator TimerAttack1() //Cool Down del disparo
    {
        isCoolDownAttack1 = false;
        yield return new WaitForSeconds(CoolDownAttack1);
        isCoolDownAttack1 = true;
    }

    private IEnumerator TimerAttack2() //Cool Down del disparo
    {
        isCoolDownAttack2 = false;
        yield return new WaitForSeconds(CoolDownAttack2);
        isCoolDownAttack2 = true;
    }
}
