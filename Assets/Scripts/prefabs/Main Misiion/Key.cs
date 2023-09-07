using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public GameObject fireSkull;
    public GameObject worm;
    public GameObject nightmare;
    public float spawnDistance = 5f;
    private bool start13 = false;

    private AudioSource healSound;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            healSound = GameObject.FindGameObjectWithTag("KeySound").GetComponent<AudioSource>();
            healSound.Play();
            if (!start13)
            {
                start13 = true;
                for (int i = 0; i < 5; i++)
                {
                    SpawnWorm();
                    SpawnFireSkull();
                }
                SpawnNightmare();
            }

            Hatch.keyFound = true;

            GameObject[] missionObjects = GameObject.FindGameObjectsWithTag("Mission");

            // Изменить текст в компоненте TextMeshPro каждого объекта Mission
            foreach (GameObject missionObject in missionObjects)
            {
                // Получить компонент TextMeshPro
                TextMeshProUGUI textMesh = missionObject.GetComponent<TextMeshProUGUI>();

                if (textMesh != null)
                {
                    // Изменить текст
                    textMesh.text = "Come back to the hatch and get out of this hell";
                }
                else { Debug.Log("asdasd"); }
            }
            Destroy(gameObject);
        }
        
    }






    void SpawnWorm()
    {
        // Вычисляем случайную позицию вокруг игрока
        Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // Создаем экземпляр врага на вычисленной позиции
        GameObject enemy = Instantiate(worm, spawnPosition, Quaternion.identity);
    }

    void SpawnNightmare()
    {
        // Вычисляем случайную позицию вокруг игрока
        Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // Создаем экземпляр врага на вычисленной позиции
        GameObject enemy = Instantiate(nightmare, spawnPosition, Quaternion.identity);
    }

    void SpawnFireSkull()
    {
        // Вычисляем случайную позицию вокруг игрока
        Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // Создаем экземпляр врага на вычисленной позиции
        GameObject enemy = Instantiate(fireSkull, spawnPosition, Quaternion.identity);
    }
}