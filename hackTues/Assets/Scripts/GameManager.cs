using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Bar sunBar;
    [SerializeField]
    private Bar watBar;
    [SerializeField]
    private Bar radBar;
    private float waitTime = 0f;
    private List<FlowerLogic> flowersInGame = new List<FlowerLogic>();
    private bool isPressed;

    private bool hatch;

    public GameObject mainObject;
    public UIHandler ui;
    public GameObject flowerRoot;

    public List<Sprite> buttonContractSprites;
  
    public FlowerLogic mainFlower;
    public float randomStart, randomEnd;
    public float powerOfEvents;
    public ResearchManager ResearchMan;



    [SerializeField]
    private List<GameObject> uiStore;
    [SerializeField]
    private List<GameObject> uiContract;

    private void Start()
    {
        populateUI();
        //ResearchMan = gameObject.GetComponent<ResearchManager>();
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
            //Debug.Log("set to: " + value);
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

        if (mainFlower.life >= 2)
        {
            if (Input.GetKey(KeyCode.F))
            {
                badEvents[UnityEngine.Random.Range(0, 3)](10, mainFlower);
            }

            //Debug.Log(mainFlower);
            if (mainFlower.life != 0)
            {
                mainFlower.water -= mainFlower.waterDec * Time.deltaTime;


                if (HatchOpen && !mainFlower.nocturnal)
                {
                    mainFlower.sun += mainFlower.sunDec * Time.deltaTime;
                }
                else if (!mainFlower.nocturnal)
                {
                    mainFlower.sun -= mainFlower.sunDec * Time.deltaTime;
                }
            }


            // Debug.Log(mainFlower.sun.ToString());
            // Debug.Log(mainFlower.water.ToString());

            if ((mainFlower.water <= 0 || mainFlower.water >= mainFlower.waterTolerance) || (mainFlower.sun <= 0 || mainFlower.sun >= mainFlower.sunTolerance))
            {
                mainFlower.life--;
                mainFlower.growSprite();
                mainFlower.sun = 0;
                mainFlower.water = 0;
                //Destroy(gameObject);
            }

            keyPressing();

            sunBar.SetBarPercent(toPercent(mainFlower.sun, mainFlower.sunTolerance));
            watBar.SetBarPercent(toPercent(mainFlower.water, mainFlower.waterTolerance));
            radBar.SetBarPercent(toPercent(mainFlower.rad, mainFlower.radTolerance));
        }
    }

    private float toPercent(float current, float max)
    {
        return current / max * 100;
    }

    public void buyFlower(FlowerLogic flower)
    {
        if(Resources.Money >= flower.flowerCost)
        {
            mainFlower.Load(flower);
        }
    }

    private void populateUI()
    {
        float temp;
        Text t;
        Transform g;
        Research unlockedRes;

        int random = UnityEngine.Random.Range(0, ResearchMan.resUnlock.Count);
        for (int i = 0; i < uiStore.Count; i++)
        {
            unlockedRes = ResearchMan.resUnlock[random];
             
            uiStore[i].transform.Find("GameObject").GetComponent<BuyHandler>().flower = unlockedRes.flower;
            g = uiStore[i].transform.Find("GameObject").Find("Name");
            t = g.gameObject.GetComponent<Text>();

            t.text = unlockedRes.flower.plantName;
            

            g = uiStore[i].transform.Find("GameObject").Find("GameObject").Find("Cost");
            t = g.gameObject.GetComponent<Text>();
            temp = unlockedRes.flower.flowerCost;
            t.text = temp.ToString("N2");

            g = uiStore[i].transform.Find("Description");
            t = g.gameObject.GetComponent<Text>();
            t.text = unlockedRes.Desc;

            uiStore[i].transform.Find("Button").GetComponent<Image>().sprite = ResearchMan.resUnlock[random].Img;
        }
        //uiStore[0]
    }

    private void keyPressing()
    {

        if (Input.GetKey(KeyCode.W) && !isPressed)
        {
            isPressed = true;
            Debug.Log("water");
            Water();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            isPressed = true;
            Hatch();
            Debug.Log("hatch");
        }
        if (Input.GetKey(KeyCode.S))
        {
            isPressed = true;
            Sell(15);
            Debug.Log("  ");
        }


        if (Input.GetKeyUp(KeyCode.Q))
        {
            isPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.W) && isPressed)
        {
            isPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isPressed = false;
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
        //Debug.Log("Watered");
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
