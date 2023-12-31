using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{

    public SelfDestruct Explosion;

    public Sprite[] animationSprites;

    public float animationTime;

    public Action died;

    private SpriteRenderer _spriteRenderer;

    private int _animationFrame;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(Animate), animationTime, animationTime);
    }

    private void Animate()
    {
        _animationFrame++;
        if (_animationFrame >= animationSprites.Length) _animationFrame = 0;
        _spriteRenderer.sprite = animationSprites[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        died.Invoke();
        gameObject.SetActive(false);
        SelfDestruct explosion = Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }
}
