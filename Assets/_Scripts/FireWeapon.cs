using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWeapon : MonoBehaviour
{
    public Button button;
    public Transform firepoint;
    public GameObject projectile;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(Shoot);
    }


    void Shoot()
    {
        GameObject BulletClone = Instantiate(projectile, firepoint.position, firepoint.transform.rotation);
        BulletClone.SetActive(true);
    }
}
