using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnRiver : Enemy {

    [SerializeField]
    float minActivationTime, maxActivationTime;

    void OnCollisionEnter2D(Collision2D col)
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y,transform.localScale.z);
        Move();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Edge"))
        {
            Invoke("Move", Random.Range(minActivationTime, maxActivationTime));
        }
    }
}
