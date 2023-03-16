using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject minighostPrefab;
    [SerializeField]
    private GameObject uglyghostPrefab;
    [SerializeField]
    private GameObject demonPrefab;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private float minighostInterval = 3f;
    [SerializeField]
    private float uglyghostInterval = 4f;

    private Transform target;
    private Transform target2;
    private Transform target3;

    [SerializeField]
    private AudioSource spawnSoundEffect;    

    [SerializeField]
    private AudioSource spawnDemonSoundEffect; 

    private Demon initialDemon;

    private Player player;

    private bool spawnDemon = false;  

    private float playerHealth;

    private ScoreSystem scoreSystem;

    void Start()
    {
        cam.SetActive(false);
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        initialDemon = GameObject.FindWithTag("Demon").GetComponent<Demon>();
        StartCoroutine(spawnEnemy(minighostInterval, minighostPrefab));
        StartCoroutine(spawnEnemy(uglyghostInterval, uglyghostPrefab));
        target = GameObject.FindWithTag("Obelisk").transform;
        target2 = GameObject.FindWithTag("Obelisk1").transform;
        target3 = GameObject.FindWithTag("Obelisk2").transform;
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        playerHealth = player.getHealth();
        Debug.Log(scoreSystem.getScore());
        Debug.Log(enemy != null);
        Debug.Log(player.getHealth());
        if (enemy != null && scoreSystem.getScore() <= 20 && playerHealth > 0)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3((target.position.x + target3.position.x)/2 + Random.Range(-1f, 1), (target.position.y+ target2.position.y)/2 - 4, -3), Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));
            GameObject newEnemy2 = Instantiate(enemy, new Vector3((target.position.x + target3.position.x)/2 + Random.Range(-1f, 1), (target.position.y+ target2.position.y)/2 - 4, -3), Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));
            GameObject newEnemy3 = Instantiate(enemy, new Vector3((target.position.x + target3.position.x)/2 + Random.Range(-1f, 1), (target.position.y+ target2.position.y)/2 - 4, -3), Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));
            spawnSoundEffect.Play();
        }
    }

    void Update()
    {
        if (scoreSystem.getScore() > 40 && !spawnDemon)
        {
            spawnDemonSoundEffect.Play();
            initialDemon.SetAlive();
            spawnDemon = true;
        }
    }
}
