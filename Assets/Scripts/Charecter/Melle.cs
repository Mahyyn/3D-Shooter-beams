using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melle : Enemy
{
    [SerializeField] Animation anim;
    [SerializeField] AudioClip hitSfx;
    override protected void Start()
    {
        stopDistance = 3;
        attackRate = 1;
        money = Random.Range(1, 6);
        base.Start();
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        playerHealth.value -= enemyData.damage;
        anim.Play();
        audioSource.PlayOneShot(hitSfx);
    }
}
