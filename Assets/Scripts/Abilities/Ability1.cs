using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ability1 : MonoBehaviour
{
    float duration = 5f;
    float cooldown = 30f;
    protected KeyCode key;
    float timerDuration;
    float timerCooldown;
    bool used = false;
    [SerializeField] AbilityData ability;
    [SerializeField] BoolVariable pause; 
    void Start()
    {
        key = KeyCode.Q;
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
        if(timerCooldown > 0)
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
        if(timerDuration<=0)
        {
            Cancel();
            timerCooldown = cooldown;
            timerDuration = duration;
            used = false;
        }
    }


    void Use()
    {
        if(ability.value == 1)
        {
            TimeStop();
        }
        else if (ability.value == 2)
        {
            Invisible();
        }
        else if (ability.value == 3)
        {
            TPGun();
        }
    }

    void Cancel()
    {
        if (ability.value == 1)
        {
            Time.timeScale = 1;
        }
        else if (ability.value == 2)
        {
            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy>().invis = false;

            }
            GetComponent<Gun>().invis =false;
        }

                       
    }

    void TimeStop()
    {
        Time.timeScale = 0;
    }
    void Invisible()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
          enemy.GetComponent<Enemy>().invis = true;

        }
        GetComponent<Gun>().invis = true;
    }
    void TPGun()
    {
        GetComponent<Gun>().tp = true;
        if (Input.GetMouseButtonDown(0))
        {
            timerDuration = 0;
        }
    }
    

}
