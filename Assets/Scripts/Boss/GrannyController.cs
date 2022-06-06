using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyController : MonoBehaviour
{

    //Player
    public PlayerController PlayerController;

    //Vida 
    private int maxHealth = 150;
    private float currentHealthGranny;
    public HealthGranny healthGranny;

    public GameObject healthPannel;

    private bool hasBeenAttacked;

    //Disparo
    public GameObject xancla;
    public bool isCoolDownAttack1;
    private float CoolDownAttack1 = 4;
    public GameObject ShotPivot;

    public GameObject mandibula;
    private bool isCoolDownAttack2;
    private float CoolDownAttack2 = 8;
    public GameObject ShotPivot2;
    public GameObject ShotPivot3;
    public GameObject ShotPivot4;


    public GameObject cadira;
    private bool isCoolDownAttack3;
    private float CoolDownAttack3 = 10;
    public GameObject ShotPivot5;
    public GameObject ShotPivot6;
    public GameObject ShotPivot7;
    public GameObject ShotPivot8;


    //Modos
    public bool normalMode;
    public bool midMode;
    public bool hardMode;


    // Start is called before the first frame update
    void Start()
    {
        currentHealthGranny= 150;

        isCoolDownAttack1 = false;
        isCoolDownAttack2 = false;
        isCoolDownAttack3 = false;

        hasBeenAttacked = false;

        healthPannel.SetActive(false);

        //Modos
        normalMode = true;
        midMode = false;
        hardMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentHealthGranny);

        if (isCoolDownAttack1 && !PlayerController.gameOver)
        {
            Instantiate(xancla, ShotPivot.transform.position, transform.rotation);

            StartCoroutine(TimerAttack1());
            isCoolDownAttack1 = false;
        }

        if (isCoolDownAttack2 && !PlayerController.gameOver && midMode)
        {
            Instantiate(mandibula, ShotPivot2.transform.position, ShotPivot2.transform.rotation);
            Instantiate(mandibula, ShotPivot3.transform.position, ShotPivot3.transform.rotation);
            Instantiate(mandibula, ShotPivot4.transform.position, ShotPivot4.transform.rotation);
            StartCoroutine(TimerAttack2());
            isCoolDownAttack2 = false;
        }

        if (isCoolDownAttack3 && !PlayerController.gameOver && hardMode)
        {
            Instantiate(cadira, ShotPivot5.transform.position, ShotPivot5.transform.rotation);
            Instantiate(cadira, ShotPivot6.transform.position, ShotPivot6.transform.rotation);
            Instantiate(cadira, ShotPivot7.transform.position, ShotPivot7.transform.rotation);
            Instantiate(cadira, ShotPivot8.transform.position, ShotPivot8.transform.rotation);
            StartCoroutine(TimerAttack3());
            isCoolDownAttack3 = false;
        }

        if (currentHealthGranny < 100)
        {
            normalMode = false;
            midMode = true;
            hardMode = false;
        }

        if (currentHealthGranny < 50)
        {
            normalMode = false;
            midMode = true;
            hardMode = true;
        }

        if (currentHealthGranny <= 0)
        {

        }
    }


    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Proyectil"))
        {
            TakeDamage(30);
            healthPannel.SetActive(true);
            
            if(!hasBeenAttacked)
            {
                StartCoroutine(StartAttack());
                hasBeenAttacked = true;
            }
            
        }
    }

    void TakeDamage(int damage)
    {
        currentHealthGranny -= damage;
        healthGranny.SetHealth(currentHealthGranny);
    }

    void HealDamage(int damage)
    {
        currentHealthGranny += damage;
        healthGranny.SetHealth(currentHealthGranny);
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

    private IEnumerator TimerAttack3() //Cool Down del disparo
    {
        isCoolDownAttack3 = false;
        yield return new WaitForSeconds(CoolDownAttack3);
        isCoolDownAttack3 = true;
    }

    private IEnumerator StartAttack() //Cool Down del disparo
    {
        isCoolDownAttack1 = false;
        isCoolDownAttack2 = false;
        yield return new WaitForSeconds(3);
        isCoolDownAttack2 = true;
        isCoolDownAttack1 = true;    
    }
}
