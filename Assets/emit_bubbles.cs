using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emit_bubbles : MonoBehaviour {
    public GameObject bubble;
    public float interval=1;
    public float newBubbleCreationTime=0;
    public float timeSinceLastBubble = 0;
	// Use this for initialization
	void Start () {
        newBubbleCreationTime = Random.Range(interval - interval / 2, interval + interval / 2);
    }

    // Update is called once per frame
    void Update () {
        timeSinceLastBubble += Time.deltaTime;
        if(timeSinceLastBubble > newBubbleCreationTime)
        {
            newBubbleCreationTime = Random.Range(interval - interval / 2, interval + interval / 2);
            timeSinceLastBubble = 0;

            Instantiate(bubble, transform.position,transform.rotation);

        }

    }
}
