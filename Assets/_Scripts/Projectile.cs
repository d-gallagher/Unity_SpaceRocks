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
  
      public void KillOldBullet()
    {
        Destroy(gameObject, 2.5f);
    }
}
