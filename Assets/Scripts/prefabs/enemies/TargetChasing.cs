using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TargetChasing : MonoBehaviour
{
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
       // Physics2D.IgnoreLayerCollision(6, 8, true);
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
            currentWayPoint ++;
        }

        if (force.x >= 0.1f && facingRight)
            Flip();
        else if (force.x <= -0.1f && !facingRight)
            Flip();

       

        //if (force.x >= 0.1f)
        //{
        //    Vector3 theScale = transform.localScale;
        //    theScale.x *= 1;

        //}
        //else
        //{
        //    if (force.x <= -0.1f)
        //    {
        //        Vector3 theScale = transform.localScale;
        //        theScale.x *= -1;

        //    }
        //}
    }

    private void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
