using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IShootable {


    [SerializeField]
    protected int speed;
    [SerializeField]
    int pointValue;

    protected Rigidbody2D rb;
    Animator anim;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    protected void Move()
    {
        rb.velocity = Vector2.right * speed * transform.localScale.x;
    }

    public void Explode()
    {
        GameManager.Score += pointValue;

        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;

        anim.Play("Exploding");
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
    
}
