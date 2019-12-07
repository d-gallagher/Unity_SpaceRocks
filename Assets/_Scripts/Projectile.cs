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

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("asteroid"))
        {
            Debug.Log("Bullet Impact Asteroid: "+hitInfo.name);
            Destroy(gameObject);
            Destroy(hitInfo.gameObject);
        }
    }
  
      public void KillOldBullet()
    {
        Destroy(gameObject, 2.5f);
    }
}
