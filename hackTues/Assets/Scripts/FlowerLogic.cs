using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerLogic : AbstractFlower
{
    public int growIndex = 0;

    public Sprite empty;
    public int lifeTime = 10;
    public List<Sprite> spritesAlive;
    public List<Sprite> spritesDead;
    public float resOnDeath;
    

    public void Load(FlowerLogic flower)
    {
        this.plantName = flower.plantName;
        this.sun = flower.sun;
        this.sunTolerance = flower.sunTolerance;
        this.sunDec = flower.sunDec;

        this.water = flower.water;
        this.waterTolerance = flower.waterTolerance;
        this.waterDec = flower.waterDec;
        this.watering = flower.watering;

        this.rad = flower.rad;
        this.radTolerance = flower.radTolerance;

        this.spritesAlive = flower.spritesAlive;
        this.spritesDead = flower.spritesDead;
        this.growIndex = flower.growIndex;
        this.empty = flower.empty;
    }

    private void Start()
    {
        if(spritesAlive != null)
        {
            changePlant("cactus");
            Invoke("growSprite", growTime);
        }
        
    }

     //open to allow sun

    
    private void FixedUpdate()
    {

    }
    //change the plant sprite
    public void changePlant(string plantTag)
    {
        spritesAlive = GameObject.FindGameObjectWithTag(plantTag).GetComponent<PlantGrow>().growAnima;
        spritesDead = GameObject.FindGameObjectWithTag(plantTag).GetComponent<PlantGrow>().deathAnima;
    }

    private void plantDry()
    {    }

    //iterate through the sprites every sprite time seconds
    public void growSprite()
    {

        Debug.Log(growIndex);
        if(growIndex > (spritesAlive.Count - 1))
        {
            if (life != 2)
            {
                if (life <0)
                {
                    return;
                }
                GetComponent<SpriteRenderer>().sprite = spritesDead[((growIndex - 1) * 2) + (1 - life)];
                life--;
                Invoke("growSprite", growTime);
            }
            return;
        }
        if(life != 2)
        {
            if(life == 0)
            {
                return;
            }
            if(growIndex == 0)
            {
                GetComponent<SpriteRenderer>().sprite = empty;
                return;
            }
            GetComponent<SpriteRenderer>().sprite = spritesDead[(growIndex * 2 - 1) + (1- life)];
            life--;
            return;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = spritesAlive[growIndex];
            growIndex++;
        }

        Invoke("growSprite", growTime);
    }
}
