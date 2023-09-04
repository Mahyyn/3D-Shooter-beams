using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableReset : MonoBehaviour
{
    [SerializeField] FloatVariable wave, money, playerHealth;
    [SerializeField] EnemyData boss, melle, shooter;
    [SerializeField] GunData gunData;
    [SerializeField] BoolVariable immortal, pause;
    [SerializeField] AbilityData ability1, ability2, ability3;

    void Awake()
    {
        wave.value = 0;
        gunData.damage = 15;
        gunData.range = 10;
        gunData.fireRate = 0.75f;
        gunData.magazine = 20;
        gunData.magazineSize = 20;
        gunData.ammo = 100;
        playerHealth.value = 50;
        shooter.health = 50;
        melle.health = 75;
        shooter.damage = 25;
        melle.damage = 15;
        boss.damage = 50;
        boss.health = 500;
        immortal.value = false;
        pause.value = false;
        money.value = 0;
        ability1.value = 0;
        ability2.value = 0;
        ability3.value = 0;
        ability1.coolDown = 0;
        ability2.coolDown = 0;
        ability3.coolDown = 0;

    }
}
