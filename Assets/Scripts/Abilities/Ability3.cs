using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability3 : MonoBehaviour
{
    float duration = 10f;
    float cooldown = 60f;
    protected KeyCode key;
    float timerDuration;
    float timerCooldown;
    bool used = false, spawned = false;
    [SerializeField] AbilityData ability;
    [SerializeField] FloatVariable playerHealth;
    [SerializeField] GunData gunData;
    [SerializeField] EnemyData enemyData;
    [SerializeField] GameObject turret;
    [SerializeField] BoolVariable pause;
    GameObject spawnedTurret;

    void Start()
    {
        key = KeyCode.E;
        timerDuration = duration;
        timerCooldown = -1;
    }


    // Update is called once per frame
    void Update()
    {
        if (pause.value || ability.value == 0)
        {
            return;
        }
        if (timerCooldown > 0)
        {
            timerCooldown -= Time.unscaledDeltaTime;
            ability.coolDown = timerCooldown;
            return;
        }
        if (Input.GetKeyDown(key))
        {
            used = true;
        }
        if (timerDuration > 0 && used)
        {
            Use();
            timerDuration -= Time.unscaledDeltaTime;
        }
        if (timerDuration <= 0)
        {
            Cancel();
            timerCooldown = cooldown;
            timerDuration = duration;
            used = false;
        }
    }

    void Use()
    {
        if (ability.value == 1)
        {
            Boost();
        }
        else if (ability.value == 2)
        {
            Turret();
        }
        else if (ability.value == 3)
        {
           Drop();
        }
    }

    void Cancel()
    {
        if (ability.value == 1)
        {
            GetComponent<PlayerController>().moveSpeed = 9;
        }
        else if (ability.value == 2)
        {
            Destroy(spawnedTurret);
            spawned = false;
        }
    }


    void Boost()
    {
        GetComponent<PlayerController>().moveSpeed = 20;
    }

    void Drop()
    {
        gunData.ammo += 50;
        playerHealth.value += enemyData.health*2;
        timerDuration = 0;
    }

    void Turret()
    {
        if (!spawned)
        {
            spawned = true;
            spawnedTurret = Instantiate(turret, new Vector3(transform.position.x + 1, transform.position.y+1, transform.position.z + 1), Quaternion.identity);
        }
    }

}
