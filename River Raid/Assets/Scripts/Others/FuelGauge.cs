﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelGauge : MonoBehaviour, IShootable {

    [SerializeField]
    int pointValue;

    public void Explode()
    {
        GameManager.Score += pointValue;

        GetComponent<Animator>().Play("Exploding");
       GetComponent<Collider2D>().enabled = false;

        Player.instance.StopCoroutine("Refuel");
        Player.instance.StopCoroutine("ConsumeFuel");
        Player.instance.StartCoroutine("ConsumeFuel");
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
