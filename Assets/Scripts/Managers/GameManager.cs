using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] Player playerPrefab;

    GameObject tempEnemy;

    public static GameManager instance;

    public ScoreManager scoreManager;

    private Weapon meleeWeapon = new Weapon("Melee", 1, 0);

    bool isEnemySpawning;
    [SerializeField] float enemySpawnRate;

    private Player player;

    public PickupSpawner pickupSpawner;

    public Action OnGameStart;
    public Action OnGameEnd;

    bool isPlaying;

    public static GameManager GetInstance()
    {
        return instance;
    }

    void SetSingleton()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;
    }

    void CreateEnemy()
    {
        tempEnemy = Instantiate(enemyPrefab);
        tempEnemy.transform.position = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)].position;
        tempEnemy.GetComponent<Enemy>().weapon = meleeWeapon;
        tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2, 0.25f);
    }

    public void NotifyDeath(Enemy enemy)
    {
        pickupSpawner.SpawnPickup(enemy.transform.position);
    }

    private void Awake()
    {
        SetSingleton();
    }
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();

        isEnemySpawning = true;
        StartCoroutine(EnemySPawner());
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(1))
        {
            CreateEnemy();
        }*/
    }

    IEnumerator EnemySPawner()
    {
        while(isEnemySpawning)
        {
            yield return new WaitForSeconds(1 / enemySpawnRate);
            CreateEnemy();
        }
    }

    void FindPlayer()
    {
        try
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }catch(NullReferenceException e)
        {
            Debug.Log("There is no player in the scene");
        }
    }

    public Player GetPlayer()
    {
        return player;
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public void StartGame()
    {
        enemySpawnRate = 1;

        player = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
        player.OnDeath += StopGame;
        isPlaying = true;

        OnGameStart?.Invoke();
        StartCoroutine(GameStarter());
    }

    IEnumerator GameStarter()
    {
        yield return new WaitForSeconds(2);
        isEnemySpawning = true;
        StartCoroutine(EnemySPawner());
    }

    public void StopGame()
    {
        isEnemySpawning = false;
        scoreManager.SetHighScore();

        StartCoroutine(GameStopper());
    }

    IEnumerator GameStopper()
    {
        isEnemySpawning = false;
        yield return new WaitForSeconds(2);
        isPlaying = false;

        foreach(Enemy item in FindObjectsOfType(typeof(Enemy)))
        {
            Destroy(item.gameObject);
        }

        foreach (Pickup item in FindObjectsOfType(typeof(Pickup)))
        {
            Destroy(item.gameObject);
        }

        OnGameEnd?.Invoke();
    }
}
