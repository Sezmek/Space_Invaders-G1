using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Base_speed = 250;
    Vector2 movement;
    public GameObject bullet;
    public Rigidbody2D Rb { get { return GetComponent<Rigidbody2D>(); } }
    void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Rb.velocity = movement * Base_speed * Time.deltaTime;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(bullet);
            go.transform.position = transform.position;
        }
    }
}
