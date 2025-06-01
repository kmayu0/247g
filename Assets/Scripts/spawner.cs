using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject apple;
    public GameObject knife;
    public float spawnInterval = 0.5f;
    public float xRange = 4f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 1f, spawnInterval);
    }

    void SpawnObject()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-xRange, xRange), transform.position.y);
        GameObject toSpawn = Random.value < 0.7f ? apple : knife; // 70% apples
        Instantiate(toSpawn, spawnPos, Quaternion.identity);
    }
}
