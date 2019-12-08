using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{

    private Camera mainCam;
    public Rigidbody2D rb;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
