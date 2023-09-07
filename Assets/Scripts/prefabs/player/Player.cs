using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public static float offset;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public Animator animator;

    public AudioSource stepSound;

    private bool isFacingRight = true;
   // private bool run = false;
    private float sprint = 1;

    //PhotonView view;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 9, true);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
      //  view = GetComponent<PhotonView>();

        //if (view.Owner.IsLocal)
        //{
        //    Camera mainCamera = Camera.main;
        //    if (mainCamera != null)
        //    {
        //        mainCamera.GetComponent<MainCamera>().player = gameObject.transform.gameObject;
        //    }
        //}
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint = 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprint = 1;
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //if (view.IsMine)
        //{
            

        
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


            rb.velocity = movement * moveSpeed * sprint;

            animator.SetFloat("speed", rb.velocity.magnitude);

            //if (moveHorizontal > 0 && !isFacingRight)
            //{
            //    Flip();
            //}
            //else if (moveHorizontal < 0 && isFacingRight)
            //{
            //    Flip();
            //}
       // }
    }

    private void Flip()
    {
            isFacingRight = !isFacingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void PlayStepSound()
    {
        //if (view.IsMine)
        //{
            stepSound.Play();
        //}
    }


}
