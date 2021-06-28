using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    [SerializeField] Attacker[] enemies;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;


    bool keepSpawning = true;

    public void StopSpawning()
    {
        keepSpawning = false;
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (keepSpawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnEnemy();
        }

        
    }

    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        
        Spawn(enemyIndex);

    }

    private void Spawn(int enemyIndex)
    {
        Attacker newEnemy = Instantiate(enemies[enemyIndex], transform.position, Quaternion.identity);
        newEnemy.transform.parent = transform;
    }


}
