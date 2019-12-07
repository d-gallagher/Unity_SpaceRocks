using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveByTouch : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D rb;
    public Slider sliThruster;

    public bool leftPressed;
    public bool rightPressed;
    private float rotationSpeed = 200f;
    public float MaxSpeed = 8f;
    //public float thrust;

    private void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ControlRocket();

        if (leftPressed && !rightPressed)
        {
            RotateLeft();
        }
        else if (!leftPressed && rightPressed)
        {
            RotateRight();
        }
    }

    private float GetThrust(Slider s)
    {
        //thrust = s.value;
        return s.value;
    }

    private void ControlRocket()
    {
        rb.AddForce(transform.up * GetThrust(sliThruster));
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -MaxSpeed, MaxSpeed), 
            Mathf.Clamp(rb.velocity.y, -MaxSpeed, MaxSpeed));
    }

    #region == Rotation ==

    public void SetRightPressed(bool pressed)
    {
        rightPressed = pressed;
    }

    public void SetLeftPressed(bool pressed)
    {
        leftPressed = pressed;
    }

    void RotateRight()
    {
        Player.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void RotateLeft()
    {
        Player.transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }
    #endregion
}