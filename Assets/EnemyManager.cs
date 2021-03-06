﻿using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager _instance;
    private GameObject _enemyPrefab;
    public List<GameObject> listEnemies = new List<GameObject>();
    public GameObject[] listSpawns;

    private TimeManager tManager;
    private float Timer;
    private float secToWait = 5f;

    // Static singleton property
    public static EnemyManager Instance
    {
        // Here we use the ?? operator, to return 'instance' if 'instance' does not equal null
        // otherwise we assign instance to a new component and return that
        get { return _instance ?? (_instance = GameObject.Find("GameManagerObject").AddComponent<EnemyManager>()); }
    }

    // Use this for initialization
    public void StartSpawning()
    {
        _enemyPrefab = Resources.Load("Prefab/Enemy") as GameObject;
        listSpawns = GameObject.FindGameObjectsWithTag("EnemySpawn");
        tManager = GameObject.Find("Directional Light").GetComponent<TimeManager>();
        Timer = Time.time + secToWait;

    }

    private void SpawnEnemy()
    {
        listEnemies.Add(Instantiate(_enemyPrefab, listSpawns[Random.Range(0, listSpawns.Length)].transform));
        Debug.Log("EnemySpawned");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Timer < Time.time && !tManager.DayTime())
        {
            SpawnEnemy();
            Timer = Time.time + secToWait;
        }
    }
}
