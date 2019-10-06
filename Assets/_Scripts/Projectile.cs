using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;
        KillOldBullet();
    }

    void OnTriggerEnter2D(Collider2D hitInfo){

        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
  
      public void KillOldBullet()
    {
        Destroy(gameObject, 5.0f);
    }
}
