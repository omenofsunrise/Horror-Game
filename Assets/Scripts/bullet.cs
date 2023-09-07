using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public int damage = 1;

    void Start()
    {
        // ������ �������� �������� ���� ������
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;

        // ������ ����� ����� ����
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Enemy"))
        {
     
            other.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            // ��������� ������������ � �������� ���� "Player"
            Debug.Log("Bullet collided with Player");
        }

        // ���������� ���� ����� ������������
        Destroy(gameObject);
    }
}
