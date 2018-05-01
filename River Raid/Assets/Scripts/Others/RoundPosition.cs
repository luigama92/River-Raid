using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundPosition : MonoBehaviour {
    
	void LateUpdate () {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z);
    }
}
