using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorChasing : MonoBehaviour
{
    public string targetTag = "Player"; // Тег целевого объекта
    public string obstacleTag = "Obstacle"; // Тег объектов-препятствий
    public float moveSpeed = 2f; // Скорость движения

    private GameObject targetObject; // Целевой объект
    private Transform[] obstacleTransforms; // Массив трансформов препятствий
    private int currentObstacleIndex; // Индекс текущего препятствия
    private float obstacleDistance = 1f; // Расстояние от объекта до препятствия

    private void Start()
    {
        // Найти целевой объект по тегу
        targetObject = FindNearestPlayerObject();

        // Найти все объекты-препятствия по тегу
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(obstacleTag);

        // Создать массив трансформов препятствий
        obstacleTransforms = new Transform[obstacles.Length];

        // Заполнить массив трансформов препятствий
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacleTransforms[i] = obstacles[i].transform;
        }

        // Установить начальный индекс препятствия
        currentObstacleIndex = 0;
    }

    private void Update()
    {
        // Проверить, что целевой объект и препятствия существуют
        if (targetObject != null && obstacleTransforms.Length > 0)
        {
            // Получить текущий трансформ препятствия
            Transform currentObstacleTransform = obstacleTransforms[currentObstacleIndex];

            // Вычислить направление к целевому объекту
            Vector2 direction = (targetObject.transform.position - transform.position).normalized;

            // Проверить, есть ли препятствие на пути и двигаться вокруг него, если есть
            if (Physics2D.Raycast(transform.position, direction, obstacleDistance))
            {
                // Повернуть направление на 90 градусов влево
                direction = Quaternion.Euler(0, 0, 45) * direction;

                // Обновить направление
                direction.Normalize();
            }

            // Переместить объект в направлении к целевому объекту
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Проверить, достиг ли объект текущего препятствия
            if (Vector2.Distance(transform.position, currentObstacleTransform.position) < obstacleDistance)
            {
                // Увеличить индекс текущего препятствия
                currentObstacleIndex++;

                // Проверить, достигли ли мы последнего препятствия в массиве
                if (currentObstacleIndex >= obstacleTransforms.Length)
                {
                    // Вернуться к первому препятствию
                    currentObstacleIndex = 0;
                }
            }
        }
    }

    private GameObject FindNearestPlayerObject()
    {
        GameObject nearestPlayer = null;
        float closestDistance = Mathf.Infinity;

        // Находим все объекты с тегом "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // Перебираем все объекты Player и находим ближайший
        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestPlayer = player;
            }
        }

        return nearestPlayer;
    }
}
