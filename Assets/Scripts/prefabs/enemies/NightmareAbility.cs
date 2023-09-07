using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NightmareAbility : MonoBehaviour
{
    public string playerTag = "Player";
    private Transform target;
    public float speed;
    public float nextWayPointDistance = 3f;

    private bool facingRight = true;
    private float move;

    Path path;
    int currentWayPoint = 0;
    private bool reachedEndOfPath;
    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        target = FindNearestPlayerTransform();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);

    }

    void UpdatePath()
    {
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distanve = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distanve < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
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

    private void Update()
    {
        // Находим все объекты с тегом "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        if (players.Length == 0)
            return;

        // Находим ближайший объект с тегом "Player"
        GameObject nearestPlayer = players[0];
        float nearestDistance = Vector2.Distance(transform.position, nearestPlayer.transform.position);

        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < nearestDistance)
            {
                nearestPlayer = player;
                nearestDistance = distance;
            }
        }

        // Вычисляем направление к ближайшему игроку
        Vector2 direction = nearestPlayer.transform.position - transform.position;

        // Вычисляем угол поворота в радианах
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Поворачиваем объект в сторону игрока
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    




}
