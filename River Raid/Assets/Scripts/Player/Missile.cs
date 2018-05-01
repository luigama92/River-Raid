using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    [SerializeField]
    float speed;
    Rigidbody2D rb;
    Player player;

    void Awake()
    {
        player = GetComponentInParent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(GameManager.dificulty==1)
            rb.velocity = new Vector2(player.rb.velocity.x, player.rb.velocity.y + speed);
        else
            rb.velocity = Vector2.up * (speed + player.rb.velocity.y);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        gameObject.SetActive(false);
    }
}
