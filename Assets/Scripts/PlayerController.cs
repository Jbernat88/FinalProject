using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    //Movimiento
    public float speed = 8f;
    public float baseSpeed;
    public bool speedModifier;
    public float modifiedSpeed =4f;
    public float turnspeed = 40f;
    private float horizontalInput;
    private float verticalInput;
    public float jumpForce = 200f;
    public float downForce = 10000f;
    public bool downSplash;
    public bool canReduce;
    private float hitForce = 100f;
    private float yRange = -20;

    //Doble Salto
    public bool isOnGround;
    public bool lookRight = true;
    public bool lookLeft;
    public bool doubleJump = true;   
    private bool IsCoolDown = true;
    public float jumpSpeed = 0.5f;//Lo que tarda en poder volver a saltar

    //Disparo
    public GameObject proyectil;
    private bool IsCoolDownShot = true;
    public float shootSpeed = 1f;
    public GameObject shootPivot;
 
    //Vida
    public int maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;


    //Municio
    private int rounds= 100;

    //Particles
    public ParticleSystem DownCrash;

    //Animaciones
    private Animator animator;
    private bool justJumped;
  

    //Efectos
    public float chromaticAb;
    public float depthField;
    public float lensDistortion;

    //GameOver
    public bool gameOver;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

        //Max Health
        currentHealth = 75;
        healthBar.SetHealth(currentHealth);

        canReduce = true;
        modifiedSpeed = 4f;

        gameOver = false;

    }


    void Update()
    {
        
        // Usamos los inputs del Input Manager
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (!gameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput, Space.World);

        }
            

        if (horizontalInput < 0 || horizontalInput > 0)
        {
            if (isOnGround)
            {
                animator.SetBool("IsMoving", true);
            }
            
        }

        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            justJumped = true;
            if(isOnGround == true && doubleJump == true)
            {               
                playerRigidbody.AddForce(Vector3.up * jumpForce);
                
                animator.SetTrigger("IsJump");
                
                
                isOnGround = false;
                doubleJump = true;

                if (!speedModifier)
                {
                    speed = 5;
                }
                StartCoroutine(CoolDown());
            }
            else if (doubleJump == true)
            {
                animator.SetTrigger("IsJump");
                playerRigidbody.AddForce(Vector3.up * jumpForce);
                doubleJump = false;
                
            }            

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isOnGround == false)
            {
                playerRigidbody.AddForce(Vector3.down * downForce);

                downSplash = true;
                
            }
        }

        if ( horizontalInput < 0 && lookRight==true)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            lookRight = false;
            lookLeft = true;
        }

       

        if (horizontalInput > 0 && lookLeft == true)
        {

            transform.Rotate(new Vector3(0, 180, 0));
            lookLeft = false;
            lookRight = true;
        }


        //Disparo

        if (Input.GetKey(KeyCode.Mouse0) && IsCoolDownShot && rounds>0 && !gameOver)
        {
            Instantiate(proyectil, shootPivot.transform.position, transform.rotation);

            StartCoroutine(CoolDownShot());

            rounds--;

            TakeDamage(10);

            animator.SetTrigger("IsThrow");

            //soundManager.SelecionAudio(0, 0.2f);
        }

     

        //Health
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        if(currentHealth < 50 && canReduce)
        {
            speedModifier = true;         
            if(speedModifier)
            {
                speed = modifiedSpeed;    
            }
            canReduce = false;

        }

        if (currentHealth < 50 && speedModifier)
        {
            if (horizontalInput < 0 || horizontalInput > 0)
            {
                if (isOnGround)
                {
                    animator.SetBool("IsWalk", true);
                }
            }
            else
            {
                animator.SetBool("IsWalk", false);
            }    
           
        }

        if (currentHealth > 50 && !canReduce && speedModifier)
        {
            speed = baseSpeed;
            canReduce = true;
            speedModifier = false;
            animator.SetBool("IsWalk", false);
        }

        if (currentHealth > 100)
        {
            chromaticAb = 1;
            depthField = 82;
            lensDistortion = -0.79f;

        }
        if (currentHealth < 100)
        {
            chromaticAb = 0;
            depthField = 0;
            lensDistortion = 0f;

        }

        if(currentHealth <= 0)
        {
            gameOver = true;
            animator.SetBool("IsDie", true);
        }

        if (transform.position.y < yRange)
        {
            TakeDamage(150);
        }
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        

        if (otherCollider.gameObject.CompareTag("Beer")) //Moneda
        {
            Destroy(otherCollider.gameObject);
            rounds++;
            HealDamage(10);

        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("ground"))
        {
            
            if(justJumped)
            {
                animator.SetTrigger("IsLand");
                justJumped = false;
            }
                      
            isOnGround = true;
            doubleJump = true;

            if(!speedModifier)
            {
                speed = baseSpeed;
                 
            }
        }


        if (otherCollider.gameObject.CompareTag("ground") && downSplash==true)
        {        
            DownCrash = Instantiate(DownCrash, transform.position, DownCrash.transform.rotation);
            DownCrash.Play();
            downSplash = false;
        }

        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(30);
        }

        if ( otherCollider.gameObject.CompareTag("Enemy") && downSplash == true)
        {
            Vector3 offset = new Vector3(0, -0.5f, 0);
            DownCrash = Instantiate(DownCrash, transform.position + offset, DownCrash.transform.rotation);
            DownCrash.Play();
            Destroy(otherCollider.gameObject);
            downSplash = false;
        }
        if (otherCollider.gameObject.CompareTag("Car") || otherCollider.gameObject.CompareTag("Bolla") || otherCollider.gameObject.CompareTag("Pinxos"))
        {
            TakeDamage(150);
            //playerRigidbody.AddForce(Vector3.backwards * hitForce);
        }
    }
  

    private IEnumerator CoolDown() //Cool Down del salto
    {
        IsCoolDown = false;
        yield return new WaitForSeconds(jumpSpeed);
        IsCoolDown = true;
        
    }

    private IEnumerator CoolDownShot() //Cool Down del disparo
    {
        IsCoolDownShot = false;
        yield return new WaitForSeconds(shootSpeed);
        IsCoolDownShot = true;
    }

    //TakeDamage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void HealDamage(int damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);
    }

}


