using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float spinSpeedBullet = 30f;
    public float roteSpeedMoney = 30;
    

    void Update()
    {

        if(gameObject.CompareTag("Proyectil"))
        {
            transform.Rotate(Vector3.right, spinSpeedBullet * Time.deltaTime);
        }

        if (gameObject.CompareTag("Beer"))
        {
            transform.Rotate(Vector3.up, roteSpeedMoney * Time.deltaTime);
        }

    }
}
