using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private float waitTime = 0f;
    private float setTimeToWait = 1.0f;

    public float powerOfEvents;
    public FlowerLogic flower;

    private void Start()
    {
        Invoke("startBad", UnityEngine.Random.Range(1, 2));
    }

    private Action<float, FlowerLogic>[] badEvents = {
        new Action<float, FlowerLogic>(StaticEvents.CosmicRays),
        new Action<float, FlowerLogic>(StaticEvents.MeteorShower),
        new Action<float, FlowerLogic>(StaticEvents.SuperNova)
    };
    
    void Update()
    {
        

        waitTime += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.F))
        {
            badEvents[UnityEngine.Random.Range(0, 3)](10, flower);
        }
    }

    private void startBad()
    {
        badEvents[UnityEngine.Random.Range(0, 3)](10, flower);
        Invoke("startBad", UnityEngine.Random.Range(1, 2));
        Debug.Log("Bad event");
    }
}
