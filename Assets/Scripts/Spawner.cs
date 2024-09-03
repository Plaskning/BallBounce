using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;

    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [Space]
    [SerializeField] private float minYHeight;
    [SerializeField] private float maxYHeight;
    [SerializeField] private float spawnTimeModifier;
    [Space]
    [SerializeField]private float timeElapsed;
    [SerializeField] private float checkSphereSize = 0.5f;
    
    private float nextSpawnTime;

    private void Start()
    {
        CalculateEnemySpawn();
    }
    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        int counter = 0;
        while (timeElapsed > nextSpawnTime && counter < 100)
        {
            counter++;
            timeElapsed -= nextSpawnTime;
            SpawnEnemy();
        }
    }

    private void CalculateEnemySpawn()
    {    
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime) * spawnTimeModifier;
        //nextSpawnTime

    }

    private void SpawnEnemy()
    {
        Vector2 positionToSpawn;
        int counter = 0;
        do
        {
            float yPos = Random.Range(minYHeight, maxYHeight);
            positionToSpawn = new Vector2(transform.position.x, yPos);

            counter++;
        } while(Physics2D.OverlapCircle(positionToSpawn, checkSphereSize) && counter < 100);

        Instantiate(Enemy, positionToSpawn, Quaternion.identity);
        CalculateEnemySpawn();
    }
}
