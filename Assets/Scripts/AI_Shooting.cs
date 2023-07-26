using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Shooting : MonoBehaviour
{
    public GameObject Bullet;

    float timer = 0;
    public float shotTime = 2;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > shotTime )
        {
            timer -= shotTime;
            shotTime = 2;
            int randchild = Random.Range(0, transform.childCount);

            GameObject buller = Instantiate(Bullet);
            Bullet.transform.position = transform.GetChild(randchild).position;
        }
    }
}
