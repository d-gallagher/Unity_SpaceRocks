using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint = null;
    public GameObject projectile;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }

    
    void Shoot()
    {
            GameObject BulletClone = Instantiate(projectile, firepoint.position, transform.rotation);
            BulletClone.SetActive(true);
            // BulletClone.GetComponent().KillOldBullet();
            // BulletClone.GetComponent().AddForce(transform.up * 350);
    }
}
