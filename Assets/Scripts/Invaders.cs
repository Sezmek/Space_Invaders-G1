using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;
    public Projectile Missile;
    public int rows = 5;
    public int columns = 10;
    private Vector3 _direction = Vector2.right;
    public AnimationCurve speed;
    public int currentlyAlive => totalInvaders - InvadersDead;
    public int InvadersDead {  get; private set; }
    public int totalInvaders => rows * columns;
    public float MissileSpeed = 1f;

    public float percentKilled => (float)InvadersDead / (float)totalInvaders;
    private void Awake()
    {
       
        for (int row =0; row < rows; row++)
        {
            float widht = 2 * (columns -1);
            float height = 2 * (rows - 1);
            Vector2 centering = new Vector2(-widht / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x,centering.y + (row * 2.0f), 0);
            for (int column = 0; column < columns; column++)
            {
                Invader invader = Instantiate(prefabs[row], transform);
                invader.died += OnInvaderDies;
                Vector3 position = rowPosition;
                position.x += column * 2.0f;
                invader.transform.localPosition = position;
            }
            
        }    
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), MissileSpeed, MissileSpeed);
    }

    private void MissileAttack()
    {
        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy) continue;
            if (Random.value < (1.0f / (float)currentlyAlive))
            {
                Instantiate(Missile, invader.position, Quaternion.identity);
                break;
            }
        }
    }
    private void Update()
    {
        this.transform.position += _direction * speed.Evaluate(percentKilled) * Time.deltaTime;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy) continue;
            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x -1)) AdvanceRow();
            else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x +1)) AdvanceRow();
        }
    }
    private void AdvanceRow()
    {
        _direction *= -1;
        Vector3 positon = transform.position;
        positon.y -= 1;
        this.transform.position = positon;
    }

    private void OnInvaderDies()
    {
        InvadersDead++;
    }
}
