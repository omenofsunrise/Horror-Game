using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    public TextMeshProUGUI bulletsText;
    public GameObject bullet;
    public Transform firePoint;

    public AudioSource emptySound;
    public AudioSource ShotSound;

    public float fireRate = 1f; // Время между выстрелами
    private float nextFireTime = 0f; // Время следующего доступного выстрела
    public float fireRate1 = 1f; // Время между выстрелами
    private float nextFireTime1 = 3f; // Время следующего доступного выстрела

    public float bullets = 20;

    //PhotonView view;

    void Start()
    {
      //  view = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
        //if (view.IsMine)
        //{

            if (Input.GetMouseButton(0))
            {
                if (bullets > 0)
                {
                    if (Time.time >= nextFireTime)
                    {
                        Shoot();
                    }
                }
                else
                {
                    if (Time.time >= nextFireTime1)
                    {
                        nextFireTime1 = Time.time + 1f / fireRate1;
                        emptySound.PlayOneShot(emptySound.clip, emptySound.volume);
                        //place sound of empty magazine here
                    }
                }
            }
       // }
    }

    private void FixedUpdate()
    {
        bulletsText.text = bullets.ToString();
    }
    

    private void Shoot()
    {
        //if (view.IsMine)
        //{
            ShotSound.Play();
            nextFireTime = Time.time + 1f / fireRate; // Обновляем время следующего доступного выстрела

            Instantiate(bullet, firePoint.position, transform.rotation);
            bullets -= 1;
       // }
    }

    public void GetAmmo(float ammoAmount)
    {
        bullets += ammoAmount;
    }

}
