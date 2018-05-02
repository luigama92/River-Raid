using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour, IShootable {

    [SerializeField]
    int pointValue;

    public void Explode()
    {
        GameManager.Score += pointValue;

        GetComponent<Animator>().Play("Exploding");
        Camera.main.GetComponent<Animator>().Play("Exploding",0,0); // brilho no rio
        GetComponent<Collider2D>().enabled = false;

        GameManager.GenerateMap();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
