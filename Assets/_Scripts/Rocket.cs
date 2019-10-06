using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float thrust = 10f;
    public float rotationSpeed = 200f;
    public float MaxSpeed = 8f;
    private Camera mainCam;
    public Rigidbody2D rb;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        ControlRocket();
        CheckPosition();
    }

    private void Update()
    {
        // if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        // {
        //     Shoot();
        // }
    }

    private void ControlRocket()
    {
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        rb.AddForce(transform.up * thrust * Input.GetAxis("Vertical"));
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -MaxSpeed, MaxSpeed), Mathf.Clamp(rb.velocity.y, -MaxSpeed, MaxSpeed));

    }

    private void CheckPosition()
    {
        // Set screen size
        float sceneWidth = mainCam.orthographicSize * 2 * mainCam.aspect;
        float sceneHeight = mainCam.orthographicSize * 2;
        // Set screen edges
        float sceneRightEdge = sceneWidth / 2;
        float sceneLeftEdge = sceneRightEdge * -1;
        float sceneTopEdge = sceneHeight / 2;
        float sceneBottomEdge = sceneTopEdge * -1;

        // Check if ship is in boundary, flip to opposite edge 
        if (transform.position.x > sceneRightEdge)
        {
            transform.position = new Vector2(sceneLeftEdge, transform.position.y);
        }

        if (transform.position.x < sceneLeftEdge)        
        { 
            transform.position = new Vector2(sceneRightEdge, transform.position.y); 
        } 
        
        if (transform.position.y > sceneTopEdge)
        {
            transform.position = new Vector2(transform.position.x, sceneBottomEdge);
        }

        if (transform.position.y < sceneBottomEdge)
        {
            transform.position = new Vector2(transform.position.x, sceneTopEdge);
        }
    }

}
