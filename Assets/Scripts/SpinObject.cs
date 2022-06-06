using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    private float spinSpeedBullet = 30f;
    private float roteSpeedMoney = 30;
    private float roteBackgroundSpeed = 30;
    private float roteAttackSpeed = 100;



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

        if (gameObject.CompareTag("Background"))
        {
            transform.Rotate(Vector3.up, roteBackgroundSpeed * Time.deltaTime);
        }

        if (gameObject.CompareTag("RotateAttack"))
        {
            transform.Rotate(Vector3.up, roteBackgroundSpeed * Time.deltaTime);
        }

        if (gameObject.CompareTag("RotateAttack"))
        {
            transform.Rotate(Vector3.right, roteBackgroundSpeed * Time.deltaTime);
        }

    }
}
