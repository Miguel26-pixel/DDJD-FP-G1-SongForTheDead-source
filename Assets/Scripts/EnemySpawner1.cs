using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    [SerializeField]
    private GameObject minighostPrefab;
    [SerializeField]
    private GameObject uglyghostPrefab;

    [SerializeField]
    private float minighostInterval = 1f;
    [SerializeField]
    private float uglyghostInterval = 2f;

    private Transform target;

    
    void Start()
    {
        StartCoroutine(spawnEnemy(minighostInterval, minighostPrefab));
        StartCoroutine(spawnEnemy(uglyghostInterval,uglyghostPrefab));
        target = GameObject.FindWithTag("Obelisk1").transform;
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(target.position.x + Random.Range(-1f,1), target.position.y-4, 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
