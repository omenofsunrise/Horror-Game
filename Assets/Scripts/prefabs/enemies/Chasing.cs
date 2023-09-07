using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorChasing : MonoBehaviour
{
    public string targetTag = "Player"; // ��� �������� �������
    public string obstacleTag = "Obstacle"; // ��� ��������-�����������
    public float moveSpeed = 2f; // �������� ��������

    private GameObject targetObject; // ������� ������
    private Transform[] obstacleTransforms; // ������ ����������� �����������
    private int currentObstacleIndex; // ������ �������� �����������
    private float obstacleDistance = 1f; // ���������� �� ������� �� �����������

    private void Start()
    {
        // ����� ������� ������ �� ����
        targetObject = FindNearestPlayerObject();

        // ����� ��� �������-����������� �� ����
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(obstacleTag);

        // ������� ������ ����������� �����������
        obstacleTransforms = new Transform[obstacles.Length];

        // ��������� ������ ����������� �����������
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacleTransforms[i] = obstacles[i].transform;
        }

        // ���������� ��������� ������ �����������
        currentObstacleIndex = 0;
    }

    private void Update()
    {
        // ���������, ��� ������� ������ � ����������� ����������
        if (targetObject != null && obstacleTransforms.Length > 0)
        {
            // �������� ������� ��������� �����������
            Transform currentObstacleTransform = obstacleTransforms[currentObstacleIndex];

            // ��������� ����������� � �������� �������
            Vector2 direction = (targetObject.transform.position - transform.position).normalized;

            // ���������, ���� �� ����������� �� ���� � ��������� ������ ����, ���� ����
            if (Physics2D.Raycast(transform.position, direction, obstacleDistance))
            {
                // ��������� ����������� �� 90 �������� �����
                direction = Quaternion.Euler(0, 0, 45) * direction;

                // �������� �����������
                direction.Normalize();
            }

            // ����������� ������ � ����������� � �������� �������
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // ���������, ������ �� ������ �������� �����������
            if (Vector2.Distance(transform.position, currentObstacleTransform.position) < obstacleDistance)
            {
                // ��������� ������ �������� �����������
                currentObstacleIndex++;

                // ���������, �������� �� �� ���������� ����������� � �������
                if (currentObstacleIndex >= obstacleTransforms.Length)
                {
                    // ��������� � ������� �����������
                    currentObstacleIndex = 0;
                }
            }
        }
    }

    private GameObject FindNearestPlayerObject()
    {
        GameObject nearestPlayer = null;
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
                nearestPlayer = player;
            }
        }

        return nearestPlayer;
    }
}
