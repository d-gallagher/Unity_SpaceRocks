using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveByKeyboard : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D rb;
    public float thrust = 10f;
    private float rotationSpeed = 200f;
    public float MaxSpeed = 8f;

    private void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ControlRocket();
    }

    private void ControlRocket()
    {
        Player.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        rb.AddForce(transform.up * thrust * Input.GetAxis("Vertical"));
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -MaxSpeed, MaxSpeed), 
            Mathf.Clamp(rb.velocity.y, -MaxSpeed, MaxSpeed));

    }

}
