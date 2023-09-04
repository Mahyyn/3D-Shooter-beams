using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPBullet : MonoBehaviour
{
    public Transform player;
    [SerializeField] Transform hitEffect;
    float timer = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0)
        {
            Destroy(gameObject);
        }
        timer-=Time.deltaTime;
        GetComponent<Rigidbody>().velocity = transform.forward * 20;
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 p;
        p= transform.position;
        p.y+=2;
        player.position = p;
        Instantiate(hitEffect, transform.position + (transform.forward * (-20 * Time.deltaTime)), transform.rotation);
        Destroy(gameObject);
    }

    
}
