using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] float tallObstacleChance = 0.2f;
    [SerializeField] GameObject coin;


    public void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if(random < tallObstacleChance) obstacleToSpawn = tallObstaclePrefab;
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        GameObject coinToSpawn = coin;
        int coinSpawnIndex = Random.Range(5, 8);
        Transform spawnPoint = transform.GetChild(coinSpawnIndex).transform;
        

        int coinSize = Random.Range(1, 7);
        for (int i = 0; i < coinSize; i++)
        {
            Vector3 newCoinPos = new(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z + i);
           Instantiate(coinToSpawn, newCoinPos, Quaternion.identity, transform);
        }
    }
}
