using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newtrap : MonoBehaviour
{
    public int spawnAmount = 2;

    public GameObject nightmare;
    public GameObject worm;
    public float spawnDistance = 10f;
    private Transform playerTransform;

    bool start = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!start)
            {
                playerTransform = FindNearestPlayerTransform();
                start = true;
                for (int i = 0; i < spawnAmount; i++)
                {
                    SpawnWorm();
                }
                SpawnNightmare();
            }
        }
    }



    void SpawnNightmare()
    {
        // ��������� ��������� ������� ������ ������
        Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // ������� ��������� ����� �� ����������� �������
        GameObject enemy = Instantiate(nightmare, spawnPosition, Quaternion.identity);
    }

    void SpawnWorm()
    {
        // ��������� ��������� ������� ������ ������
        Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // ������� ��������� ����� �� ����������� �������
        GameObject enemy = Instantiate(worm, spawnPosition, Quaternion.identity);
    }

    private Transform FindNearestPlayerTransform()
    {
        Transform nearestPlayerTransform = null;
        float closestDistance = Mathf.Infinity;

        // ������� ��� ������� � ����� "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // ���������� ��� ������� Player � ������� ���������
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