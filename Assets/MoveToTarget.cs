using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour {
    public GameObject Target;
    public float minDistance=3;
    public float speed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Target.transform);

        if (Vector3.Distance(gameObject.transform.position, Target.transform.position) > minDistance)
        {
            transform.Translate(0,0, speed * Time.deltaTime);
        }

    }
}
