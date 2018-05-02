using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    [SerializeField]
    float speed;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(GameManager.dificulty==1)
            rb.velocity = new Vector2(Player.instance.rb.velocity.x, Player.instance.rb.velocity.y + speed);
        else
            rb.velocity = Vector2.up * (speed + Player.instance.rb.velocity.y);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        gameObject.SetActive(false);
        
        IShootable shootable = other.GetComponent<IShootable>();
        if (shootable != null)
            shootable.Explode();
    }
}
