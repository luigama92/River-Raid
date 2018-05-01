using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundPosition : MonoBehaviour {
    
	void LateUpdate () {
            transform.position = new Vector3(Mathf.Ceil(transform.position.x), Mathf.Ceil(transform.position.y), transform.position.z);
    }
}
