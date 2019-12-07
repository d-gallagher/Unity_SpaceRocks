using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKeyboard : MonoBehaviour
{
    public GameObject Player;

    public float thrust = 10f;
    private float rotationSpeed = 200f;
    public float MaxSpeed = 8f;

    private void FixedUpdate()
    {
        ControlRocket();
    }

    private void ControlRocket()
    {
        Player.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        Player.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust * Input.GetAxis("Vertical"));
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Clamp(Player.GetComponent<Rigidbody2D>().velocity.x, -MaxSpeed, MaxSpeed), 
            Mathf.Clamp(Player.GetComponent<Rigidbody2D>().velocity.y, -MaxSpeed, MaxSpeed));

    }
}
