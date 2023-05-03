using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPositions;

    GameObject tempEnemy;

    public static GameManager instance;

    public ScoreManager scoreManager;

    private Weapon meleeWeapon = new Weapon("Melee", 1, 0);

    bool isEnemySpawning;
    [SerializeField] float enemySpawnRate;

    private Player player;

    public PickupSpawner pickupSpawner;

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
}
