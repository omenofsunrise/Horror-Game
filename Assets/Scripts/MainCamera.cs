using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    public float z;

    void Update()
    {
        if (player != null)
        { 
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, z);
        }
    }

}
