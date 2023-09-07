using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public float minX, minY, maxX, maxY;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomposition = new Vector3 (Random.Range (minX, minX), Random.Range(maxX, maxY), -1);
        PhotonNetwork.Instantiate (player.name, randomposition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
