using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damageRate = 0.2f;
    public int damage =1;
    float nextDamageTime = 0f;
    public bool targetFound = false;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (targetFound)
        {
            if (other.gameObject.CompareTag("Player") && Time.time >= nextDamageTime)
            {
                nextDamageTime = Time.time + 1 / damageRate;
                other.GetComponent<Health>().TakeDamage(damage);
                
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (targetFound)
        {
            if (other.gameObject.CompareTag("Player") && Time.time >= nextDamageTime)
            {
                nextDamageTime = Time.time + 1 / damageRate;
                other.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
}