using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerating : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float Z = 0;
    public int spawnAmount;

    public float restrictedMinX;
    public float restrictedMaxX;
    public float restrictedMinY;
    public float restrictedMaxY;

    private void Start()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        float randomX;
        float randomY;
        Vector3 spawnPos;

        do
        {
            randomX = Random.Range(minX, maxX);
            randomY = Random.Range(minY, maxY);
            spawnPos = new Vector3(randomX, randomY, Z);
        }
        while (spawnPos.x >= restrictedMinX && spawnPos.x <= restrictedMaxX &&
               spawnPos.y >= restrictedMinY && spawnPos.y <= restrictedMaxY);

        Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
    }
}