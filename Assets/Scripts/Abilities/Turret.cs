using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Transform Enemy;
    float attackSpeed = 0.3f;
    float damage = 25;
    float ats = 0.0f;
    [SerializeField] FloatVariable playerDamage;
    [SerializeField] GameObject bullet;
    public Transform bullet_spawn;
    void Start()
    {
        damage = playerDamage.value / 5;
    }

    void Update()
    {
        try
        {
            Enemy = FindEnemy();
        }
        catch (System.NullReferenceException)
        {
            return;
        }
        transform.LookAt(Enemy);
        
        if (ats <= 0.0f)
        {
            Bullet b;
            b = Instantiate(bullet, bullet_spawn.position, bullet_spawn.rotation).GetComponent<Bullet>();
            b.SetValues(damage, 40, 20);
            bullet.transform.LookAt(Enemy);
            ats = attackSpeed;
        }
        ats -= Time.deltaTime;
    }



    public Transform FindEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float newDistance = diff.sqrMagnitude;
            if (newDistance < distance)
            {
                closest = enemy;
                distance = newDistance;
            }
        }
        return closest.transform;
    }
}
