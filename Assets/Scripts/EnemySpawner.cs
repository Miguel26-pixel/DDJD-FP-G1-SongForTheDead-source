using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject minighostPrefab;
    [SerializeField]
    private GameObject uglyghostPrefab;

    [SerializeField]
    private float minighostInterval = 6f;
    [SerializeField]
    private float uglyghostInterval = 7f;

    private Transform target;
    private Transform target2;
    private Transform target3;



    void Start()
    {
        StartCoroutine(spawnEnemy(minighostInterval, minighostPrefab));
        StartCoroutine(spawnEnemy(uglyghostInterval, uglyghostPrefab));
        target = GameObject.FindWithTag("Obelisk").transform;
        target2 = GameObject.FindWithTag("Obelisk1").transform;
        target3 = GameObject.FindWithTag("Obelisk2").transform;
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if (enemy != null)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(target.position.x + Random.Range(-1f, 1), target.position.y - 4, 0), Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));
            GameObject newEnemy2 = Instantiate(enemy, new Vector3(target2.position.x + Random.Range(-1f, 1), target2.position.y - 4, 0), Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));
            GameObject newEnemy3 = Instantiate(enemy, new Vector3(target3.position.x + Random.Range(-1f, 1), target3.position.y - 4, 0), Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
}
