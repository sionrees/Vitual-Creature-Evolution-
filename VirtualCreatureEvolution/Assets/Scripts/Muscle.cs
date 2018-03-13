using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muscle : MonoBehaviour {
    private bool pullOn = true;
    //private bool musclePair;
    private Vector3 forceDirectionA;
    private Vector3 forceDirectionB;
    private GameObject connectionA0;
    private GameObject connectionA1;
    private float timing;
    private float pullForce;
    
    void FixedUpdate()
    {

        if (pullOn)
        {
            if(connectionA0 == null)
            {
                Debug.Log("Connection A0 is null");
            }
            if (connectionA1 == null)
            {
                Debug.Log("Connection A1 is null");
            }
            forceDirectionA = connectionA0.transform.position - connectionA1.transform.position;
            forceDirectionB = connectionA1.transform.position - connectionA0.transform.position;
            connectionA0.GetComponent<Rigidbody>().AddForce(forceDirectionA * pullForce * Time.fixedDeltaTime);
            connectionA1.GetComponent<Rigidbody>().AddForce(forceDirectionB * pullForce * Time.fixedDeltaTime);
        }

    }

    void Start()
    {
        StartCoroutine(MuscleTwitch());
    }


    IEnumerator MuscleTwitch()
    {
        while (true)
        {
            yield return new WaitForSeconds(timing);
            pullOn = !pullOn;
        }
    }
    

    public Vector3 ForceDirectionA
    {
        get
        {
            return forceDirectionA;
        }

        set
        {
            forceDirectionA = value;
        }
    }

    public Vector3 ForceDirectionB
    {
        get
        {
            return forceDirectionB;
        }

        set
        {
            forceDirectionB = value;
        }
    }

    public GameObject ConnectionA0
    {
        get
        {
            return connectionA0;
        }

        set
        {
            connectionA0 = value;
        }
    }

    public GameObject ConnectionA1
    {
        get
        {
            return connectionA1;
        }

        set
        {
            connectionA1 = value;
        }
    }

    

    public float PullForce
    {
        get
        {
            return pullForce;
        }

        set
        {
            pullForce = value;
        }
    }

    public float Timing
    {
        get
        {
            return timing;
        }

        set
        {
            timing = value;
        }
    }
}
