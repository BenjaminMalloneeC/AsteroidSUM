using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public float spawnDistance;
    public GameObject player;
    public GameObject playerPrefab;
    public GameObject bullet;
    public GameObject asteroid;
    public List<GameObject> enemyList;
    public List<GameObject> enemyPrefabList;
    public List<Transform> spawnPointList;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            enemyList = new List<GameObject>();
        }
        else
        {
            Destroy(this.gameObject);
            //Debug.LogError("[GameManager] Attempted to create a second game manager." + this.gameObject.name);
        }
    }

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnEnemy()
    {
        //TODO: Not yet fully implemented

        //Pick a random enemy to spawn
        GameObject enemyToSpawn = enemyPrefabList[Random.Range(0, enemyPrefabList.Count)];

        //Pick a random spawn point to spawn at
        Transform spawnPoint = spawnPointList[Random.Range(0, spawnPointList.Count)];

        //Pick a point within distance of spawn point to spawn at
        Vector3 randomVector = Random.insideUnitCircle;
        Vector3 newPosition = spawnPoint.position + (randomVector * spawnDistance);

        //Instantiate the selected enemy at the seleceted position
        Instantiate(enemyToSpawn, newPosition, Quaternion.identity);
    }

    private void Update()
    {
        if (player != null)
        {
            //Spawn a new enemy if we have less than 3 enemies
            if (enemyList.Count < 3)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnPlayer()
    {
        if (player != null)
        {
            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
    }

    public void DestroyAllEnemies()
    {
        foreach(GameObject enemy in enemyList)
        {
            Destroy(enemy);
        }
    }
}
