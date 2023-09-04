using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy
{
    [SerializeField] Transform bullet, bulletSpawn;
    override protected void Attack()
    {
        Transform tra = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        tra.LookAt(player);
        tra.GetComponent<Bullet>().SetValues(enemyData.damage, 17, 10);
    }

    override protected void Start()
    {
        stopDistance = 10;
        attackRate = 1f;
        money = Random.Range(1, 6);
        base.Start();
    }

    
    override protected void Update()
    {
        base.Update();
    }
}
