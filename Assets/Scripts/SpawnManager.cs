using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] enemyPrefabs;

    public float enemyCounter;
    public int waveNumber = 1;
    private int skeleton = 0;
    private int slime = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountingEnemies();
        WaveController();
    }

    void CountingEnemies()
    {
        enemyCounter = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
    }

    void WaveController()
    {
        if (enemyCounter == 0)
        {
            switch (waveNumber)
            {
                case 1:
                    Instantiate(enemyPrefabs[skeleton], spawnPoints[Random.Range(0, 3)].transform.position, Quaternion.identity);
                    waveNumber++;
                    break;
                case 2:
                    Instantiate(enemyPrefabs[skeleton], spawnPoints[Random.Range(0, 3)].transform.position, Quaternion.identity);
                    Instantiate(enemyPrefabs[skeleton], spawnPoints[Random.Range(0, 3)].transform.position, Quaternion.identity);
                    waveNumber++;
                    break;
                case 3:
                    Instantiate(enemyPrefabs[skeleton], spawnPoints[Random.Range(0, 3)].transform.position, Quaternion.identity);
                    Instantiate(enemyPrefabs[skeleton], spawnPoints[Random.Range(0, 3)].transform.position, Quaternion.identity);
                    Instantiate(enemyPrefabs[skeleton], spawnPoints[Random.Range(0, 3)].transform.position, Quaternion.identity);
                    waveNumber++;
                    break;
            }
        }
    }
}
