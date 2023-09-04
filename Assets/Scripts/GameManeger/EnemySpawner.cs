using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] FloatVariable wave;
    [SerializeField] EnemyData melleData, bossData, shooterData;
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject boss;
    float enemyBoost = 0, max = 5;
    bool bossBool;
    public void Spawn()
    {
        wave.value++;
        max = wave.value % 5 * 5;
        if (max == 0)
        {
            max = 10;
            bossBool = true;
            enemyBoost += 15;
            bossData.health += enemyBoost * 20;
            bossData.damage += enemyBoost * 3;
            melleData.health += enemyBoost * 2;
            melleData.damage += enemyBoost;
            shooterData.health += enemyBoost;
            shooterData.damage += enemyBoost * 2;

        }
        if (bossBool)
        {
            Vector3 spawnPos = new Vector3(-50, 13, -6);
            Instantiate(boss, spawnPos, Quaternion.identity);
            bossBool = false;
        }

        for (int i = 0; i < max; i++)
        {
            GameObject enemy;
            enemy = enemies[Random.Range(0, enemies.Length)];
            Vector3 spawnPos = new Vector3(Random.Range(-100, 50), 4, Random.Range(-50, 77));
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }
}
