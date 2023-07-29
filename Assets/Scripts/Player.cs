using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Projectile laserprefab;
    Vector2 movement;
    public float Base_speed = 250;
    private bool _laserActive;
    public Rigidbody2D Rb { get { return GetComponent<Rigidbody2D>(); } }
    void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Rb.velocity = movement * Base_speed * Time.deltaTime;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();

    }
    void Shoot()
    {
        if (!_laserActive)
        {
            Projectile projectile = Instantiate(laserprefab, transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        }   
    }
    void LaserDestroyed()
    {
        _laserActive = false;
    }
}
