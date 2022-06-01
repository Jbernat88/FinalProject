using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10;
    public float rotateSpeed = 200;
    private Rigidbody objectRigidbody;
    public float upForce = 2;



    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {

        //El objeto se mueve hacia delante constantemente
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        
        objectRigidbody.AddForce(transform.up * upForce);
    }
}
