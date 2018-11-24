using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bubble_behaviour : MonoBehaviour {
    public float t = 0;
    public float ls = 0;
    public float destroyTime=1.2f;
    public float destroyTimeCounter = 0;
    public float upSpeed = 0;

	// Use this for initialization
	void Start () {
        t = Random.Range(0.5f, 3.5f);
        upSpeed = Random.Range(0.5f, 1.5f);
        transform.Rotate(Random.Range(-10f, +10f), Random.Range(-10f, +10f), Random.Range(-10f, +10f));
        transform.localScale = new Vector3(Random.Range(0.05f, 0.12f), Random.Range(0.05f, 0.12f), Random.Range(0.05f, 0.12f));
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        destroyTimeCounter += Time.deltaTime;
        if (t > 8)
        {
            t = 0;
        }
        ls = Mathf.Sin(t*Mathf.PI/2) ;
        transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y + (ls/200 * transform.localScale.x),transform.localScale.z);
        transform.Translate(0, upSpeed * Time.deltaTime, 0);

        if(destroyTimeCounter > destroyTime)
        {
            Destroy(gameObject);
        }

    }
}
