using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{

    public Slider sliThruster;
    
    public float MaxSpeed = 8f;
    private Camera mainCam;
    public Rigidbody2D rb;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        CheckPosition();
    }

    private float GetThrust(Slider s)
    {
        return s.value;
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
