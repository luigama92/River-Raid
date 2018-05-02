﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour, IShootable {

    [SerializeField]
    int pointValue;

    public void Explode()
    {
        GameManager.Score += pointValue;

        GetComponent<Animator>().Play("Exploding");
        Camera.main.GetComponent<Animator>().Play("Exploding",0,0);
        GetComponent<Collider2D>().enabled = false;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

}