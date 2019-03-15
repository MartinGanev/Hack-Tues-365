using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private float waitTime = 0f;

    private float setTimeToWait = 1.0f;

    private void Start()
    {
        Invoke("startBad", UnityEngine.Random.Range(1, 2));
    }

    private Action<float>[] badEvents = {
        new Action<float>(StaticEvents.CosmicRays),
        new Action<float>(StaticEvents.MeteorShower),
        new Action<float>(StaticEvents.SuperNova)
    };
    
    void Update()
    {
        

        waitTime += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.F))
        {
            badEvents[UnityEngine.Random.Range(0, 3)](10);
        }
    }

    private void startBad()
    {
        badEvents[UnityEngine.Random.Range(0, 3)](10);
        Invoke("startBad", UnityEngine.Random.Range(1, 2));
        Debug.Log("Bad event");
    }
}
