using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Button button;
    public Transform firepoint;
    public GameObject projectile;

    void Start()
    {
        Transform fp = firepoint.GetComponent<Transform>();

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(Shoot);
    }

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
    }
}
