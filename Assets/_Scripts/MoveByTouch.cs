using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveByTouch : MonoBehaviour
{
    public GameObject Player;
    public Slider sliThruster;

    public bool leftPressed;
    public bool rightPressed;
    private float rotationSpeed = 200f;
    public float MaxSpeed = 8f;
    //public float thrust;

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
        //Player.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        //Player.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust * Input.GetAxis("Vertical"));
        //Player.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Clamp(Player.GetComponent<Rigidbody2D>().velocity.x, -MaxSpeed, MaxSpeed),
        //    Mathf.Clamp(Player.GetComponent<Rigidbody2D>().velocity.y, -MaxSpeed, MaxSpeed));
        Player.GetComponent<Rigidbody2D>().AddForce(transform.up * GetThrust(sliThruster));
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Clamp(Player.GetComponent<Rigidbody2D>().velocity.x, -MaxSpeed, MaxSpeed), 
            Mathf.Clamp(Player.GetComponent<Rigidbody2D>().velocity.y, -MaxSpeed, MaxSpeed));



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