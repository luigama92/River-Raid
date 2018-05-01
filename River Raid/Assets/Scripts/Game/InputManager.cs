using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (player)
        {
            player.Move();

            if (Input.GetButton("Fire1"))
                player.Shoot();
        }
    }

}
