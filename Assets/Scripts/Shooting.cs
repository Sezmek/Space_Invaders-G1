using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody2D Rb { get { return GetComponent<Rigidbody2D>(); } }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rb.velocity = transform.up * Time.deltaTime * 300;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy" && tag == "bullet")
        {
            Swarm_Movement containerScript = collision.transform.parent.GetComponent<Swarm_Movement>();
            containerScript.moveSpeed += 0.2f;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.tag == "Player" && tag == "E_bullet")
        {
            Destroy(collision.gameObject );
            Destroy(gameObject);
        }
    }
}
