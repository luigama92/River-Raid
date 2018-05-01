using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    int
        defaultSpeed,                      //velocida de movimento
        horizontalSpeed,                   //velocidade lateral
        negativeSpeed,                          //velocida diminuida quando "freia"
        bonusSpeed;                          //velocida adicionada quando acelera

    float speed;                           //velocidade atual

    int maxFuel = 62;                 //O maximo de combustivel (de acordo com o tamanho do hud)
    int fuelConsumptionRate = 2;      //Velocidade que vai sendo consumido a cada segundo
    int fuel;                         //Quantiade atual de conbustivel
    public Image fuelPointer;

    public GameObject missile;
    [HideInInspector]
    public Rigidbody2D rb;
    Animator anim;

    void Awake()
    {
        fuel = maxFuel;
        StartCoroutine("ConsumeFuel");

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

    IEnumerator ConsumeFuel()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (fuel > 0)
            {
                fuel -= fuelConsumptionRate;
                fuelPointer.rectTransform.Translate(-fuelConsumptionRate, 0, 0);
            }
            else
                Explode();
        }
    }

    IEnumerator Refuel()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            if (fuel < maxFuel)
            {
                fuel += fuelConsumptionRate;
                fuelPointer.rectTransform.Translate(fuelConsumptionRate, 0, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fuel"))
            StartCoroutine("Refuel");
        else
            Explode();

        if (other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().Explode();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Fuel"))
            StopCoroutine("Refuel");
    }
}
