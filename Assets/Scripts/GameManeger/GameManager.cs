using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] FloatVariable playerHealth;
    [SerializeField] BoolVariable pause;
    [SerializeField] GameObject shop, pauseMenu, settingsMenu,deathMenu;
    float previousTimeScale;
    float countDown = 7;
    [SerializeField] TMP_Text countDownText;

    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<EnemySpawner>().Spawn();

    }

    void Update()
    {
        if (countDown > 0)
        {
            CountDown();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause.value)
            {
                pauseMenu.SetActive(false);
                settingsMenu.SetActive(false);
                pause.value = false;
                Time.timeScale = previousTimeScale;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pause.value = true;
                pauseMenu.SetActive(true);
                previousTimeScale = Time.timeScale;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;

            }
        }

        
        OnDeath();
        RespawnEnemies();


    }


    void RespawnEnemies()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            return;
        }
        shop.SetActive(true);
        pause.value = true;
        Cursor.lockState = CursorLockMode.None;
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Escape))
        {
            pause.value = false;
            GetComponent<EnemySpawner>().Spawn();
            shop.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            countDown = 5;
        }


    }
    

    void OnDeath()
    {
        if (playerHealth.value <= 0)
        {
            deathMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            pause.value = true;
            Time.timeScale = 0;
            playerHealth.value = 0;
        }
    }

    void CountDown()
    {
        Time.timeScale = 0;
        countDown -= Time.unscaledDeltaTime;
        countDownText.text = Mathf.Round(countDown).ToString();
        if(countDown <= 0)
        {
            countDownText.text = "";
            Time.timeScale = 1;
        }
        
    }
}

