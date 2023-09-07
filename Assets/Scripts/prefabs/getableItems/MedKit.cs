using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    public int HealAmount;
    private AudioSource healSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            healSound = GameObject.FindGameObjectWithTag("HealSound").GetComponent<AudioSource>();
            healSound.Play();
            other.GetComponent<Health>().Heal(HealAmount);
            Destroy(gameObject);
        }
    }
}
