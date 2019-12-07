using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Movement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool buttonPressed;
    public GameObject Player;

    bool rotateL;
    bool rotateR;
    public float rotationSpeed = 200f;

    void Start()
    {
        Player = GameObject.Find("PlayerShip");
        rotateL = false;
        rotateR = false;
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

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
        Debug.Log("Pressed");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        Debug.Log("Not Pressed");
    }

    #region == Rotation ==
    void RotateLeft()
    {
        Player.transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
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
        Player.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
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
}