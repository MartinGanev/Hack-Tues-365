using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerLogic : AbstractFlower
{
    private int index = 0;

    public List<Sprite> sprites;
    public float resOnDeath;
    public float watering;

    private bool hatch;

    private void Start()
    {
        changePlant("cactus");
        Invoke("growSprite", growTime);
    }

    public bool HatchOpen
    {
        get {
            return hatch;
        }

        set {
            hatch = value;
            if (value == false) {
                /*play animation*/
            }
            else
            {
                /*play animation*/
            }
        }
    }
    
    private void FixedUpdate()
    {
        water -= waterDec * Time.deltaTime;

        if( HatchOpen && !nocturnal)
        {
            sun += sunDec * Time.deltaTime;
        }

        //Debug.Log(sun.ToString());

        if ((water <= 0 || water >= waterTolerance) || (sun <=0 || sun >= SunTolerance ))
        {
            Resources.Research += resOnDeath;
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
            Debug.Log("hatch");
            HatchOpen = !HatchOpen;
        }
        if (Input.GetKey(KeyCode.S))
        {

        }
    }
    

    private void changePlant(string plantTag)
    {
        sprites = GameObject.FindGameObjectWithTag(plantTag).GetComponent<PlantGrow>().growAnima;
    }

    private void growSprite()
    {
        if(index > (sprites.Count - 1))
        {
            return;
        }
        GetComponent<SpriteRenderer>().sprite = sprites[index];
        index++;
        Invoke("growSprite", growTime);
    }

    private void Sell(float money)
    {

    }
    private void Water()
    {
        water += watering;
        //play animation
    }

}
