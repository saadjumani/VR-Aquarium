using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guideMoveToTarget : MonoBehaviour {

    public GameObject Target;
    public float minDistance = 3;
    public float speed = 2;

    public float t;

    public int waitTimeBeforeStart;
    public int waitTimeBeforeKiss;
    public int kissDuration;

    public int state=0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            transform.LookAt(Target.transform);

            if (Vector3.Distance(gameObject.transform.position, Target.transform.position) > minDistance)
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
            else{
                state = 1;
            }
        }

        if (state == 1)
        {
            //wait for specific time
            if (t < waitTimeBeforeKiss)
            {
                t += Time.deltaTime;
            }
            else
            {
                state = 2;
                t = 0;

            }
        }

        if(state == 2)
        {
            transform.LookAt(Target.transform);

            minDistance = 0.3f;

            if (Vector3.Distance(gameObject.transform.position, Target.transform.position) > minDistance)
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
            else
            {
                state = 3;
            }
        }

        if (state == 3)
        {
            if (t < kissDuration)
            {
                t += Time.deltaTime;
            }
            else
            {
                t = 0;
                state = 4;
            }
        }

        if (state == 4)
        {
            transform.Translate(5 * Time.deltaTime, 0, 0);
        }



    }
}
