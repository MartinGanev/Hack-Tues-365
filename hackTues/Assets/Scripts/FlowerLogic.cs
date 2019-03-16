using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerLogic : AbstractFlower
{
    
    private int index = 0;

    public Sprite empty;
    public int lifeTime = 10;
    public List<Sprite> sprites;
    public float resOnDeath;
    public float watering;



    private void Start()
    {
        growStatus = 0;
        if(sprites != null)
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
    private void changePlant(string plantTag)
    {
        sprites = GameObject.FindGameObjectWithTag(plantTag).GetComponent<PlantGrow>().growAnima;
    }

    private void plantDry()
    {    
        GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    //iterate through the sprites every sprite time seconds
    private void growSprite()
    {
        Debug.Log(index);
        if(index > (sprites.Count - 1))
        {
            return;
        }
        GetComponent<SpriteRenderer>().sprite = sprites[index];
        index++;
        Invoke("growSprite", growTime);
    }
}
