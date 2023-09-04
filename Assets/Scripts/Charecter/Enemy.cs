using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class Enemy : Character
{
    protected bool isMoving = true;
    protected float stopDistance,attackRate,money;
    float timer;
    Vector3 target;
    protected Transform player;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] protected FloatVariable playerHealth,playerMoney;
    [SerializeField] protected GunData gunData;
    [SerializeField] protected EnemyData enemyData;
    [SerializeField] TextMeshPro healthText;
    [SerializeField] protected AudioSource audioSource;
    public bool invis = false;
    protected void Move()
    {
        if (Vector3.Distance(target, transform.position) <= stopDistance)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        if (isMoving)
        {
            agent.destination = target;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            agent.destination = transform.position;
        }
        


    }
    protected void TrackPlayer()
    {
        target = player.position;
        Quaternion rotation = Quaternion.LookRotation(target - transform.position, Vector3.up);
        transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
    }
    virtual protected void Start()
    {
        health = enemyData.health;
        GetComponent<Damage>().health = health;
        healthText.text = health.ToString() + " HP";
        player = GameObject.Find("Player").transform;
        timer = attackRate;
    }


    virtual protected void Attack()
    {
        //attack
    }
    virtual protected void Update()
    {
        health = GetComponent<Damage>().health;
        if (health <= 0)
        {
            playerMoney.value += money;
            Destroy(gameObject);
            playerHealth.value += enemyData.health / 5;
            gunData.ammo += Random.Range(0,6);
            return;
        }
        healthText.text = health.ToString() + " HP";

        if (invis)
        {
            return;
        }
        TrackPlayer();
        Move();
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (!isMoving)
            {
                Attack();
                timer = attackRate;
            }
            
        }

    }
}
