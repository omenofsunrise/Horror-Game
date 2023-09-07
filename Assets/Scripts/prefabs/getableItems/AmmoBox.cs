using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public float bulletsAmount;
    private AudioSource healSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            healSound = GameObject.FindGameObjectWithTag("AmmoSound").GetComponent<AudioSource>();
            healSound.Play();
            Gun gun = other.GetComponentInChildren<Gun>(); // �������� ��������� Gun �� �������� �������� other
            if (gun != null)
            {
                gun.GetComponent<Gun>().GetAmmo(bulletsAmount);
            }
            Destroy(gameObject);
        }
    }
}

            
