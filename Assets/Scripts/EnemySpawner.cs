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

    [SerializeField]
    private AudioSource spawnSoundEffect;    

    private float spawnCounter = 0;

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
        if (enemy != null && spawnCounter <= 50)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3((target.position.x + target3.position.x)/2 + Random.Range(-1f, 1), (target.position.y+ target2.position.y)/2 - 4, -3), Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));
            spawnSoundEffect.Play();
            spawnCounter++;
        }
    }
}
