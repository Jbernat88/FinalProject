using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Script per controlar el player

    private Rigidbody playerRigidbody;

    //Movimient
    private float speed = 8f;
    private float baseSpeed =8;
    private bool speedModifier;
    private float modifiedSpeed =4f;
    private float turnspeed = 40f;
    private float horizontalInput;
    private float verticalInput;
    private float jumpForce = 300f;
    private float downForce = 500f;
    private bool downSplash;
    private bool canReduce;
    private float hitForce = 100f;
    private float yRange = -30;

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
    private int maxHealth = 150;
    public float currentHealth;
    public HealthBar healthBar;

    //Municio
    private int rounds;

    //Particles
    public ParticleSystem DownCrash;

    //Animaciones
    private Animator animator;
    private bool justJumped;
  
    //Efectos
    public float chromaticAb;
    public float depthField;
    public float lensDistortion;

    //Audios
    private SoundManager soundManager;

    //GameOver
    public bool gameOver;
    public bool gameWon;

    //Pause
    public GameObject pausePannel;
    private bool isPausePannel;

    void Start()
    {
        //Accedim en el rigidbody i a l'animator
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        soundManager = FindObjectOfType<SoundManager>();

        //Max Health
        currentHealth = 75;
        healthBar.SetHealth(currentHealth);

        //Modificador de velocitat
        canReduce = true;
        modifiedSpeed = 4f;

        //Game Over i Victory
        gameOver = false;
        gameWon = false;

        //Pannel de pause
        pausePannel.SetActive(false);
        isPausePannel = false;
    }


    void Update()
    {
        #region MOVIMENT
        //Accedim als inputs de moviment
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Deim que passa quan game over
        if (!gameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput, Space.World);
        }
        
        //Animació de correr
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

        //Bot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Determinam que acabam de botar
            justJumped = true;
            if(isOnGround == true && doubleJump == true)
            {
                //Botam i activam l'animació i les particules
                playerRigidbody.AddForce(Vector3.up * jumpForce);          
                animator.SetTrigger("IsJump");                         
                isOnGround = false;
                doubleJump = true;
                soundManager.SeleccionAudio(7, 1f);
                if (!speedModifier)
                {
                    speed = 5;
                }
                StartCoroutine(CoolDown());
            }
            //Doble bot
            else if (doubleJump == true)
            {
                soundManager.SeleccionAudio(7, 1f);
                animator.SetTrigger("IsJump");
                playerRigidbody.AddForce(Vector3.up * jumpForce);
                doubleJump = false;       
            }            
        }

        //Cop per avall
        if (Input.GetKeyDown(KeyCode.S))
        {
            //determinam si esteim a l'aire
            if (isOnGround == false)
            {
                playerRigidbody.AddForce(Vector3.down * downForce);
                downSplash = true;       
            }
        }

        //Diracció en la que mira el player
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
        #endregion

        #region DISPARO
        //Disparo
        if (Input.GetKey(KeyCode.Mouse0) && IsCoolDownShot && rounds>0 && !gameOver)
        {
            Instantiate(proyectil, shootPivot.transform.position, transform.rotation);
            soundManager.SeleccionAudio(0, 1f);
            StartCoroutine(CoolDownShot());
            rounds--;
            TakeDamage(10);
            animator.SetTrigger("IsThrow");
        }
        #endregion

        #region Vida

        //Health
        //Determinam vida maxima i feim que no es pugui superar
        if (currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        //Determinam vida minima i feim que no es pugui superar
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        //Si baixam de una certa vida reduim velocitat
        if(currentHealth < 50 && canReduce)
        {
            speedModifier = true;         
            if(speedModifier)
            {
                speed = modifiedSpeed;    
            }
            canReduce = false;
        }
        //Animació per caminar
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
        #endregion

        #region Visual
        //Feim que la vida canvii els visuals
        SetVisualValues(currentHealth);
        #endregion

        #region Game
        //Determinam game over i l'animacio de morir
        if (currentHealth <= 0)
        {
            gameOver = true;
            animator.SetBool("IsDie", true);
            soundManager.SeleccionAudio(4, 1f);
        }
        if (currentHealth >= 150)
        {
            gameOver = true;
            animator.SetBool("IsDie", true);
            soundManager.SeleccionAudio(3, 1f);
        }
        if (transform.position.y < yRange)
        {
            TakeDamage(150);
        }
        #endregion

        #region Pause
        //Pause
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            if(!isPausePannel)
            {
                pausePannel.SetActive(true);
                isPausePannel = true;
                Time.timeScale = 0;
            }
            else
            {
                pausePannel.SetActive(false);
                isPausePannel = false;
                Time.timeScale = 1;
            }   
        }
        #endregion
    }

    #region Colisions
    //Determinam que passa quan colisionam amb un recolectable
    private void OnTriggerEnter(Collider otherCollider)
    {      
        if (otherCollider.gameObject.CompareTag("Beer")) //Moneda
        {
            Destroy(otherCollider.gameObject);
            rounds++;
            HealDamage(10);
            soundManager.SeleccionAudio(1, 1f);

        }
    }
    //Determinam les colisions
    private void OnCollisionEnter(Collision otherCollider)
    {
        //Colisiiom amb enterra
        if (otherCollider.gameObject.CompareTag("ground"))
        {  
            if(justJumped)
            {
                animator.SetTrigger("IsLand");
                soundManager.SeleccionAudio(8, 1f);
                justJumped = false;
            }            
            isOnGround = true;
            doubleJump = true;
            if(!speedModifier)
            {
                speed = baseSpeed;
                 
            }
        }
        //Colisio amb enterra despres d'utilitzar la s
        if (otherCollider.gameObject.CompareTag("ground") && downSplash==true)
        {        
            DownCrash = Instantiate(DownCrash, transform.position, DownCrash.transform.rotation);
            Debug.Log("Splash");

            downSplash = false;
        }
        //Colisio amb l'enemic
        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(30);
            soundManager.SeleccionAudio(2, 1f);
        }
        //Colisio amb l'enemic 2
        if (otherCollider.gameObject.CompareTag("Enemy2"))
        {
            TakeDamage(30);
            soundManager.SeleccionAudio(2, 1f);
        }
        //Colisio amb l'atac del boss
        if (otherCollider.gameObject.CompareTag("Attack"))
        {
            TakeDamage(15);
            Destroy(otherCollider.gameObject);
            soundManager.SeleccionAudio(2, 1f);
        }
        //Colisio amb l'atac especial dle boss
        if (otherCollider.gameObject.CompareTag("Cadira"))
        {
            TakeDamage(15);
            Destroy(otherCollider.gameObject); soundManager.SeleccionAudio(2, 1f);
        }
        //Colisio amb l'enemic despres d'utilitzar la s
        if (otherCollider.gameObject.CompareTag("Enemy") && downSplash == true)
        {
            Vector3 offset = new Vector3(0, -0.5f, 0);
            DownCrash = Instantiate(DownCrash, transform.position + offset, DownCrash.transform.rotation);
            DownCrash.Play();
            Destroy(otherCollider.gameObject);
            downSplash = false;
        }
        //Colisio amb l'enemic 2 despres d'utilitzar la s
        if ( otherCollider.gameObject.CompareTag("Enemy2") && downSplash == true)
        {
            Vector3 offset = new Vector3(0, -0.5f, 0);
            DownCrash = Instantiate(DownCrash, transform.position + offset, DownCrash.transform.rotation);
            DownCrash.Play();
            Destroy(otherCollider.gameObject);
            soundManager.SeleccionAudio(6, 1f);
            downSplash = false;
        }
        //Colisio amb els obstacles
        if (otherCollider.gameObject.CompareTag("Car") || otherCollider.gameObject.CompareTag("Bolla") || otherCollider.gameObject.CompareTag("Pinxos"))
        {
            TakeDamage(150);
            soundManager.SeleccionAudio(2, 1f);
        }
    }
    #endregion

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

    public void SetVisualValues(float h)
    {
        chromaticAb = (h - 75) / (150 - 75);
       
    }
}


