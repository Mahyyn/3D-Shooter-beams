using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float damage;
    float speed = 5;
    float range;
    Vector3 startPos;
    [SerializeField] GameObject hitEffect;
    virtual protected void Start()
    {
        startPos = transform.position;
    }

   virtual protected void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        if (Mathf.Abs(transform.position.magnitude - startPos.magnitude) > range)
        {
            Destroy(gameObject);
        }

    }
    public void SetValues(float d,float r,float s)
    {
        damage = d;
        range = r;
        speed = s;
    }

    virtual protected void Collision(Collider collider ,string targetTag,string myTag)
    {
        if (collider.tag == tag || collider.tag == myTag)
        {
            return;
        }
        if (collider.tag == targetTag)
        {
            collider.GetComponent<Damage>().DoDamage(damage);
        }
        Instantiate(hitEffect,transform.position, transform.rotation);
        Destroy(gameObject);

    }

    

}
