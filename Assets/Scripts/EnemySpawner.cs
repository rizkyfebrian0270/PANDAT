using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 0=A, 1=B, 2=C
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0 || enemyPrefabs[0] == null)
        {
            Debug.LogWarning("Enemy prefab belum diisi!");
            return;
        }

        GameObject enemyToSpawn = enemyPrefabs[0];
        GameObject enemyInstance = Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
        Debug.Log("Spawned enemy: " + enemyInstance.name + " at " + spawnPoint.position);
    }

}
