using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailAnimation : MonoBehaviour {
    public float ls;
    public float t = 0;
    public float u = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        u += Time.deltaTime * 2;
        if (t > 8)
        {
            t = 0;
        }

        if (u > 4)
        {
            u = 0;
        }

        ls = Mathf.Sin(t * Mathf.PI / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + (ls / 600 * transform.localScale.x), transform.localScale.z);

        if (u < 2)
        {
            if (u < 1)
            {
                transform.Rotate(0, 0.2f, 0.8f);
            }
            else
            {
                transform.Rotate(0, 0.1f, 0.4f);
            }
        }
        else
        {
            if (u < 3)
            {
                transform.Rotate(0, -0.2f, -0.8f);
            }
            else
            {
                transform.Rotate(0, -0.1f, -0.4f);
            }
        }

    }
}

