using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public GameObject entityPrefab;
    public Transform playerTransform;
    public float spawnInterval = 2f;
    public int maxEntities = 3;
    public Vector3 spawnPoint = new Vector3(5, 0, 5);

    private float timer;
    private int currentEntities;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && currentEntities < maxEntities)
        {
            SpawnEntity();
            timer = 0f;
        }
    }

    void SpawnEntity()
    {
        GameObject instancePrefab = Instantiate(entityPrefab, spawnPoint, Quaternion.identity);
        instancePrefab.GetComponent<EnemyMovement>().playerTransform = playerTransform;
        currentEntities++;
    }

    // Call this when an entity dies
    public void EntityDestroyed()
    {
        currentEntities--;
    }
}