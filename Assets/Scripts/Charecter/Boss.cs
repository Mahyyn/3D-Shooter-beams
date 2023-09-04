using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] Transform bullet;
    [SerializeField] Transform[] bulletSpawn;
    int i = 0;

    override protected void Attack()
    {
        if (i < 4)
        {
            Transform tra = Instantiate(bullet, bulletSpawn[i].position, bulletSpawn[i].rotation);
            tra.LookAt(player);
            tra.GetComponent<BulletEnemy>().SetValues(enemyData.damage, 35, 15);
            tra.GetComponent<BulletEnemy>().track = true;
            tra.GetComponent<BulletEnemy>().target = player;
            i++;
        }
        else
        {
            i = 0;
        }


    }

    override protected void Start()
    {
        stopDistance = 30;
        attackRate = 1.5f;
        money = Random.Range(25, 75);
        base.Start();
    }


    override protected void Update()
    {
        base.Update();
    }
}
