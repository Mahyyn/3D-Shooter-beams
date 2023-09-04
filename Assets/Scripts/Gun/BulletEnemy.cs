using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    [HideInInspector] public bool track = false;
    [HideInInspector] public Transform target;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (track)
        {
            transform.LookAt(target);
        }
        base.Update();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Collision(collider, "Player", "Enemy");

    }
}
