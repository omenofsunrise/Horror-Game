using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hatch : MonoBehaviour
{
    public Animator animator;
    public GameObject button;
    public GameObject text;
    public static bool keyFound = false ;


    void Start()
    {
        animator = gameObject.GetComponent<Animator> ();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!keyFound)
            {
                button.SetActive(true);
            }
            else
            {
                button.SetActive(true);
                text.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!keyFound)
            {
                button.SetActive(false);
            }
            else
            {
                button.SetActive(false);
                text.SetActive(false);
            }
        }
    }
}