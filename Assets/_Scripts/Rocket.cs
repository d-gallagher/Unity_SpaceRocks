using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public Button btnLeft;
    public Button btnRight;
    public Slider sliThruster;

    bool rotateL;
    bool rotateR;

    float rotationSpeed = 1000f;
    public float MaxSpeed = 8f;
    private Camera mainCam;
    public Rigidbody2D rb;

    private void Start()
    {
        mainCam = Camera.main;
        Button btnL = btnLeft.GetComponent<Button>();
        btnL.onClick.AddListener(RotateLeft);
        Button btnR = btnRight.GetComponent<Button>();
        btnR.onClick.AddListener(RotateRight);

        rotateL = false;
        rotateR = false;
    }

    private void FixedUpdate()
    {
        ControlRocket();
        CheckPosition();
    }

    void Update()
    {

        if (rotateL)
        {
            RotateLeft();
        }
        else if (rotateR)
        {
            RotateRight();
        }

    }

    private float GetThrust(Slider s)
    {
        return s.value;
    }

    private void ControlRocket()
    {
        rb.AddForce(transform.up * GetThrust(sliThruster));
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -MaxSpeed, MaxSpeed), Mathf.Clamp(rb.velocity.y, -MaxSpeed, MaxSpeed));

    }
    #region == Rotation ==
    void RotateLeft()
    {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }

    public void StartRotateL()
    {
        rotateL = true;
    }

    public void StopRotateL()
    {
        rotateL = false;
    }

    void RotateRight()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }


    public void StartRotateR()
    {
        rotateR = true;
    }

    public void StopRotateR()
    {
        rotateR = false;
    }

    #endregion
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
