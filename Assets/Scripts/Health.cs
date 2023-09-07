using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject medkit;
    public GameObject ammoBox;

    public int maxHealth = 100;
    public int currentHealth;

    public Image healthBarFill;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Start()
    {
        currentHealth = maxHealth; // Устанавливаем текущее здоровье равным максимальному при запуске
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Update()
    {
        if (healthBarFill != null)
        {
            // Обновление fill Amount визуализации здоровья
            healthBarFill.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    private void FixedUpdate()
    {
        // Если цвет спрайта был изменен, возвращаем его к исходному цвету через некоторое время
        if (spriteRenderer.color != originalColor)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, originalColor, 0.1f);
        }
    }

    public void TakeDamage(int damage)
    {
        spriteRenderer.color = Color.red;


        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    private void Die()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            int chance = Random.Range(0, 8);
            if (chance == 0)
            {
                Instantiate(medkit, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (chance == 1)
            {
                Instantiate(ammoBox, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (chance > 1)
            {
                Destroy(gameObject);
            }
        }
        if (gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("DeathSpace");
        }
    }
}