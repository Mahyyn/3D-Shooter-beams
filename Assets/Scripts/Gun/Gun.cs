using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    RaycastHit hit;
    public Transform bullet;
    [SerializeField] Transform bulletSpawn,tpBullet;
    [SerializeField] GunData gunData;
    [SerializeField] BoolVariable pause;
    bool reloading = false, playedAudio=false;
    float timer;
    float reloadTimer = 1.5f;
    public bool tp = false,invis = false;
    public float dmgMutli = 1, frMulti = 1;
    [SerializeField] AudioSource audioSource;
    void Start()
    {

        timer = gunData.fireRate;
        

    }
    
    // Update is called once per frame
    void Update()
    {
        if (pause.value || invis)
        {
            return;
        }
        if (tp)
        {
            TpGun();
            return;
        }
        if (gunData.magazine <= 0)
        {
            Reload();
        }
        if (reloading)
        {
            Reload();
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            reloading = true;
        }
        
        timer -= Time.unscaledDeltaTime;
        if (timer < 0 && gunData.magazine >0)
        {
            Shoot();
            

        }
        
        
    }
    void Shoot()
    {
        Bullet b;
        if (Input.GetMouseButton(0))
        {
            gunData.magazine--;
            b = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation).GetComponent<Bullet>();
            b.SetValues(gunData.damage, gunData.range, 12);
            timer = gunData.fireRate*frMulti;
        }
    }

    void Reload()
    {
        if (!playedAudio)
        {
            audioSource.Play();
            playedAudio = true;
        }
        if (reloadTimer > 0)
        {
            reloadTimer -= Time.unscaledDeltaTime;
            return;
        }
        else
        {
            reloadTimer = 1;
            reloading = false;
            playedAudio = false;
        }
        
        if (gunData.ammo >= gunData.magazineSize)
        {
            if (gunData.magazine == 0)
            {
                gunData.ammo -= gunData.magazineSize;
                gunData.magazine = gunData.magazineSize;
            }
            else
            {
                gunData.ammo -= gunData.magazineSize - gunData.magazine;
                gunData.magazine = gunData.magazineSize;
            }
        }
        else if(gunData.ammo>0)
        {
            while (gunData.magazine < gunData.magazineSize && gunData.ammo > 0)
            {
                gunData.magazine++;
                gunData.ammo--;
            }
        }
    }

    public void TpGun()
    {
        if (Input.GetMouseButton(0))
        {
            TPBullet b;
            b = Instantiate(tpBullet, bulletSpawn.position, bulletSpawn.rotation).GetComponent<TPBullet>();
            b.player = transform;
            timer = gunData.fireRate;
            tp = false;
        }
    }
}
