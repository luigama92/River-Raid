using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInAir : Enemy
{

    float lefEdge, rightEdge;

    protected override void Awake()
    {
        lefEdge = Camera.main.ViewportToWorldPoint(Vector2.zero).x;
        rightEdge = Camera.main.ViewportToWorldPoint(Vector2.right).x;
        base.Awake();
        Move();
    }
    
    void OnEnable()
    {
        StartCoroutine("CheckIfIsOnScreen");
    }

    IEnumerator CheckIfIsOnScreen()
    {
        while (enabled)
        {
            if (transform.position.x > rightEdge)
                transform.position = new Vector3(lefEdge, transform.position.y, transform.position.z);
            else
                if (transform.position.x < lefEdge)
                    transform.position = new Vector3(rightEdge, transform.position.y, transform.position.z);
            yield return null;
        }
    }

}
