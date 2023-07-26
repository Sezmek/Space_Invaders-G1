using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
public class Swarm_Movement : MonoBehaviour
{
    public float moveSpeed = 60f; 
    private bool movingRight = true; 

    void FixedUpdate()
    {
        bool shouldChangeDirection = CheckBoundary();
        if (shouldChangeDirection)
        {
            movingRight = !movingRight;
        }
        MoveSwarm();
    }

    bool CheckBoundary()
    {
        foreach (Transform child in transform)
        {
            if (child.position.x >= 10 || child.position.x <= -10)
            {
                transform.Translate(Vector2.down * 0.25f);
                return true;
            }
        }
        return false;
    }

    void MoveSwarm()
    {
        float direction = movingRight ? 1f : -1f;
        Vector2 movement = new Vector2(direction * moveSpeed * Time.deltaTime, 0f);
        transform.Translate(movement);
    }
}
