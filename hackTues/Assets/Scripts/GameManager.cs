using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GameManager : MonoBehaviour
{
    
    private float waitTime = 0f;
    private List<FlowerLogic> flowersInGame = new List<FlowerLogic>();

    private bool hatch;

    public GameObject flowerRoot;

    public FlowerLogic mainFlower;
    public float randomStart, randomEnd;
    public float powerOfEvents;

    private void Start()
    {
        flowersInGame =  flowerRoot.GetComponentsInChildren<FlowerLogic>().ToList<FlowerLogic>();
        
        Invoke("startBad", UnityEngine.Random.Range(randomStart, randomEnd));
    }

    private Action<float, FlowerLogic>[] badEvents = {
        new Action<float, FlowerLogic>(StaticEvents.CosmicRays),
        new Action<float, FlowerLogic>(StaticEvents.MeteorShower),
        new Action<float, FlowerLogic>(StaticEvents.SuperNova)
    };

    public bool HatchOpen
    {
        get
        {
            return hatch;
        }

        set
        {
            hatch = value;
            Debug.Log("set to: " + value);
            if (value == false)
            {
                /*play animation*/
            }
            else
            {
                /*play animation*/
            }
        }
    }

    void FixedUpdate()
    {

        waitTime += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.F))
        {
            badEvents[UnityEngine.Random.Range(0, 3)](10, mainFlower);
        }

        mainFlower.water -= mainFlower.waterDec * Time.deltaTime;

        if (HatchOpen && !mainFlower.nocturnal)
        {
            mainFlower.sun += mainFlower.sunDec * Time.deltaTime;
        }

        Debug.Log(mainFlower.sun.ToString());
        Debug.Log(mainFlower.water.ToString());

        if ((mainFlower.water <= 0 || mainFlower.water >= mainFlower.waterTolerance) || (mainFlower.sun <= 0 || mainFlower.sun >= mainFlower.SunTolerance))
        {
            Resources.Research += mainFlower.resOnDeath;
            //Destroy(gameObject);
        }
    }

    private void keyPressing()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("water");
            Water();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Hatch();
            Debug.Log("hatch");
        }
        if (Input.GetKey(KeyCode.S))
        {
            Sell(15);
            Debug.Log("  ");
        }
    }

    public void Sell(float money)
    {
        Resources.Money += money;
        mainFlower.GetComponent<SpriteRenderer>().sprite = mainFlower.empty;
    }

    public void Hatch()
    {
        HatchOpen = !HatchOpen;
    }
    public void Water()
    {
        Debug.Log("Watered");
        mainFlower.water += mainFlower.watering;
        //play animation
    }

    private void startBad()
    {
        badEvents[UnityEngine.Random.Range(0, 3)](10, mainFlower);
        Invoke("startBad", UnityEngine.Random.Range(randomStart, randomEnd));
        //Debug.Log("Bad event");
    }
}
