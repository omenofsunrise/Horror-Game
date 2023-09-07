using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject FireSkull;
    public GameObject slime;
    public GameObject scane;
    public Transform playerTransform;
    public float spawnDistance = 5f;

    public TextMeshProUGUI timeText;

    private float startTime;
    private float elapsedTime;

    bool started = true;
    //bool start1 = false;
    //bool start2 = false;
    //    private bool start3 = false;
    //private bool start4 = false;
    //private bool start5 = false;
    //private bool start6 = false;
    //private bool start7 = false;
    //private bool start8 = false;
    //private bool start9 = false;
    //private bool start10 = false;
    //private bool start11 = false;
    //private bool start12 = false;
    private bool start13 = false;
        



    private void Start()
    {
        startTime = Time.time;
 
        playerTransform = FindNearestPlayerTransform(); 
    }

    private void Update()
    {
        elapsedTime = Time.time - startTime;
        string minutes = Mathf.Floor(elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00");

        timeText.text = minutes + ":" + seconds;

        
        if (elapsedTime >= 1f && started)
        {
            started = false;
            StartScane();
        }
    }

    private void FixedUpdate()
    {

        //if (elapsedTime >= 15f && !start1)
        //{
        //    for (int i = 0; i < 2; i++)
        //    {
        //        start1 = true;
        //        SpawnFireSkull();
        //    }
        //}
        //if (elapsedTime >= 40f && !start2)
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        start2 = true;
        //        SpawnFireSkull();
        //    }
        //}
        //if (elapsedTime >= 75f && !start3)
        //{
        //    start3 = true;
        //    for (int i = 0; i < 2; i++)
        //    {
        //        SpawnSlime();
        //    }
        //    for (int i = 0; i < 1; i++)
        //    {
        //        SpawnFireSkull();
        //    }
        //}
        //if (elapsedTime >= 120f && !start4)
        //{
        //    start4 = true;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        SpawnFireSkull();
        //        SpawnSlime();
        //    }
        //}
        //if (elapsedTime >= 190f && !start5)
        //{
        //    start5 = true;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        SpawnFireSkull();
        //        SpawnSlime();
        //    }
        //}
        //if (elapsedTime >= 230f && !start6)
        //{
        //    start6 = true;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        SpawnFireSkull();
        //        SpawnSlime();
        //    }
        //}

        //if (elapsedTime >= 270f && !start7)
        //{
        //    start7 = true;
        //    for (int i = 0; i < 6; i++)
        //    {
        //        SpawnSlime();
        //    }
        //}
        //if (elapsedTime >= 360f && !start8)
        //{
        //    start8 = true;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        SpawnFireSkull();
        //    }
        //}
        //if (elapsedTime >= 390f && !start9)
        //{
        //    start9 = true;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        SpawnFireSkull();
        //        SpawnSlime();
        //    }
        //}
        //if (elapsedTime >= 430f && !start10)
        //{
        //    start10 = true;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        SpawnFireSkull();
        //    }
        //    for (int i = 0; i < 1; i++)
        //    {
        //        SpawnSlime();
        //    }
        //}
        //if (elapsedTime >= 460f && !start11)
        //{
        //    start11 = true;
        //    for (int i = 0; i < 7; i++)
        //    {
        //        SpawnFireSkull();
        //    }
        //}
        //if (elapsedTime >= 510f && !start12)
        //{
        //    start12 = true;
        //    for (int i = 0; i < 2; i++)
        //    {
        //        SpawnSlime();
        //    }
        //}
        if (elapsedTime >= 600f && !start13)
        {
            start13 = true;
            for (int i = 0; i < 7; i++)
            {
                SpawnSlime();
                SpawnFireSkull();
            }
        }
    }

    void SpawnFireSkull()
    {
        // Вычисляем случайную позицию вокруг игрока
        Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // Создаем экземпляр врага на вычисленной позиции
        GameObject enemy = Instantiate(FireSkull, spawnPosition, Quaternion.identity);
    }

    void SpawnSlime()
    {
        // Вычисляем случайную позицию вокруг игрока
        Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // Создаем экземпляр врага на вычисленной позиции
        GameObject enemy = Instantiate(slime, spawnPosition, Quaternion.identity);
    }

    void StartScane()
    {
        Instantiate(scane, transform.position, Quaternion.identity);
    }

    private Transform FindNearestPlayerTransform()
    {
        Transform nearestPlayerTransform = null;
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
                nearestPlayerTransform = player.transform;
            }
        }

        return nearestPlayerTransform;
    }
}