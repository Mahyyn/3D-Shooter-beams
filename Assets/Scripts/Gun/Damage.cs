using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float health;
    [SerializeField] FloatVariable healthVar;
    [SerializeField] EnemyData enemyData;
    public bool updateVar = false,enemy,player;
    public float dmgMulti = 1;
    void Awake()
    {
        health = healthVar.value;


    }

    // Update is called once per frame
    public void DoDamage(float damage)
    {
        health-=damage*dmgMulti;
        if (updateVar)
        {
            healthVar.value -= damage * dmgMulti;
        }
    }

    
}
