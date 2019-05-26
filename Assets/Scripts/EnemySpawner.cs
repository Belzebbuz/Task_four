using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {


    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float spawnTime;

    private Player player;
    private float _spawnTimer;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        _spawnTimer = 0f;
    }
    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0f)
        {
            _spawnTimer += spawnTime;
            if (enemyPrefab != null && player != null)
            {
                Vector3 spawnPoint = player.transform.position + new Vector3(Random.value - 0.5f, 0, Random.value - 0.5f).normalized * spawnRadius;
                Instantiate(enemyPrefab, spawnPoint, Quaternion.LookRotation(player.transform.position));
            }
        }
    }
}
