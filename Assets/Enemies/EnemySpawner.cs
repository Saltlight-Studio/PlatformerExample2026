using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public UnityEvent allEnemiesDied;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int spawnAmount = 1;
    [SerializeField] float spawnRadius = 1.0f;
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] int enemiesAlive = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies();
    }
    private void SpawnEnemies()
    {
        enemiesAlive = spawnAmount;
        for (int i = 0; i < spawnAmount; i++)
        {
            //int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[i];

            Vector3 spawnOffset = Vector3.zero;
            spawnOffset.x = Random.Range(-spawnRadius, spawnRadius);
            spawnOffset.y = Random.Range(-spawnRadius, spawnRadius);

            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position + spawnOffset, Quaternion.identity);
            Health health = enemy.GetComponentInChildren<Health>();
            health.died.AddListener(EnemyDied);
        }
    }
    private void EnemyDied()
    {
        enemiesAlive -= 1;
        if (enemiesAlive <= 0)
        {
            allEnemiesDied.Invoke();
        }
    }

}
