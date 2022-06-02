using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10;
    public float rotateSpeed = 200;
    private Rigidbody objectRigidbody;
    public float upForce = 2;

    //Cotxe
    private float carSpeed = 10;
    private float zRangeCar = 20f;

    //Plataforma
    private float platformSpeed = 4;
    private float yRangePlatform = -20f;


    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {

        //Bala
        if (CompareTag("Proyectil"))
        {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        
        objectRigidbody.AddForce(transform.up * upForce);
        }


        //Cotxe
        if(CompareTag("Car"))
        {
            transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
        }

        if (transform.position.z > zRangeCar && CompareTag("Car"))
        {
            Destroy(gameObject);
        }

        //Plataformes
        if (CompareTag("Platform"))
        {
            transform.Translate(Vector3.down * platformSpeed * Time.deltaTime);
        }

        if (transform.position.y < yRangePlatform && CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
}
