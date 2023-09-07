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
        // Задаем скорость движения пули вправо
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;

        // Задаем время жизни пули
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
            // Обработка столкновения с объектом тега "Player"
            Debug.Log("Bullet collided with Player");
        }

        // Уничтожаем пулю после столкновения
        Destroy(gameObject);
    }
}
