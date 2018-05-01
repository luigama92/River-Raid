using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    float
        defaultSpeed,                      //velocida de movimento
        horizontalSpeed,                   //velocidade lateral
        negativeSpeed,                          //velocida diminuida quando "freia"
        bonusSpeed;                          //velocida adicionada quando acelera

    float speed;                           //velocidade atual

    [SerializeField]
    float maxFuel, fuelConsumptionRate;    //O maximo de combustivel e a velocidade que vai sendo consumido
    float fuel;                            //Quantiade atual de conbustivel
    

    public GameObject missile;
    [HideInInspector]
    public Rigidbody2D rb;
    Animator anim;

    void Awake()
    {
        fuel = maxFuel;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Move()
    {
        float hSpeed = Input.GetAxis("Horizontal") * horizontalSpeed;
        float vSpeed = Input.GetAxis("Vertical");

        if (vSpeed != 0)
        {
            vSpeed *= (vSpeed > 0) ? bonusSpeed : negativeSpeed;
            vSpeed += defaultSpeed;
        }
        else
            vSpeed = defaultSpeed;

        anim.SetFloat("HSpeed", hSpeed);

        if (hSpeed == 0)
            anim.Play("Default", 0, 0);

        rb.velocity = new Vector2(hSpeed, vSpeed);
    }

    public void Shoot()
    {
        if (!missile.activeSelf)
        {
            missile.SetActive(true);
            missile.transform.localPosition = Vector2.zero;
        }
    }

    public void Explode()
    {
        InputManager.player = null;
        rb.bodyType = RigidbodyType2D.Static;
        anim.Play("Exploding");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        Explode();
    }

}
