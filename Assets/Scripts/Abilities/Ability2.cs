using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability2 : MonoBehaviour
{
    float duration = 10f;
    float cooldown = 90f;
    protected KeyCode key;
    float timerDuration;
    float timerCooldown;
    bool used = false;
    [SerializeField] AbilityData ability;
    [SerializeField] BoolVariable immortal, pause;

    void Start()
    {
        key = KeyCode.X;
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
            TimeSlow();
        }
        else if (ability.value == 2)
        {
            Immortal();
        }
        else if (ability.value == 3)
        {
            Oni();
        }
    }

    void Cancel()
    {
        if (ability.value == 1)
        {
            Time.timeScale = 1f;
            GetComponent<PlayerController>().moveSpeed = 9;
        }
        else if (ability.value == 2)
        {
            immortal.value = false;
            GetComponent<Damage>().updateVar = true;
        }
        else if (ability.value == 3)
        {
            GetComponent<PlayerController>().moveSpeed = 9;
            GetComponent<Damage>().dmgMulti = 1;
            GetComponent<Gun>().dmgMutli = 1;
            GetComponent<Gun>().frMulti = 1;
        }


    }

    void TimeSlow()
    {
        Time.timeScale = 0.2f;
        GetComponent<PlayerController>().moveSpeed = 60;
    }

    void Immortal()
    {
        immortal.value = true;
        GetComponent<Damage>().updateVar = false;
    }

    void Oni()
    {
        GetComponent<PlayerController>().moveSpeed = 20;
        GetComponent<Damage>().dmgMulti = 0.5f;
        GetComponent<Gun>().dmgMutli = 2;
        GetComponent<Gun>().frMulti = 0.5f;
    }
}
