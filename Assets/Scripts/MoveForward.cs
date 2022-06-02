using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10;
    public float rotateSpeed = 200;
    private Rigidbody objectRigidbody;
    public float upForce = 2;

    private float carSpeed = 10;
    private float zRange = 20f;



    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {

        //El objeto se mueve hacia delante constantemente
        if (CompareTag("Proyectil"))
        {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        
        objectRigidbody.AddForce(transform.up * upForce);
        }

        if(CompareTag("Car"))
        {
            transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
        }

        if (transform.position.z > zRange && CompareTag("Car"))
        {
            Destroy(gameObject);
        }
    }
}
