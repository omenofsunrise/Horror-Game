using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfCheck : MonoBehaviour
{
    public Animator animator;
    public AudioSource beforeMeet;
    public AudioSource afterMeet;
    public TargetChasing script;
    public BoxCollider2D box;
    private bool start = false;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!start)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (beforeMeet != null)
                {
                    beforeMeet.Stop();
                }
                if (afterMeet != null)
                {
                    afterMeet.Play();
                }
                if (animator != null)
                {
                    animator.SetBool("attack", true);
                }
                script.enabled = true;
                box.enabled = false;
                gameObject.GetComponent<Attack>().targetFound = true;
                start = true;
            }
        }

        if (!start)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                if (beforeMeet != null)
                {
                    beforeMeet.Stop();
                }
                if (afterMeet != null)
                {
                    afterMeet.Play();
                }
                if (animator != null)
                {
                    animator.SetBool("attack", true);
                }
                script.enabled = true;
                box.enabled = false;
                gameObject.GetComponent<Attack>().targetFound = true;
                start = true;
            }
        }
    }
}