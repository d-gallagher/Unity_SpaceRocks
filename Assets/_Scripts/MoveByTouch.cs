using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public GameObject Player;

    public bool leftPressed;
    public bool rightPressed;
    private float rotationSpeed = 200f;

    void FixedUpdate()
    {
        if (leftPressed && !rightPressed)
        {
            RotateLeft();
        }
        else if (!leftPressed && rightPressed)
        {
            RotateRight();
        }
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