using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

    public Transform target;
    public float offset;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.position.y + offset, transform.position.z);
    }
}
