using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 movement;
    public float Base_speed = 250;
    public Rigidbody2D Rb { get { return GetComponent<Rigidbody2D>(); } }
    void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Rb.velocity = movement * Base_speed * Time.deltaTime;
    }
}
