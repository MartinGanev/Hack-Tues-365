using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerLogic : AbstractFlower
{
    
    private int growIndex = 0;

    public Sprite empty;
    public int lifeTime = 10;
    public List<Sprite> sprites;
    public float resOnDeath;
    



    private void Start()
    {
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
    public void changePlant(string plantTag)
    {
        sprites = GameObject.FindGameObjectWithTag(plantTag).GetComponent<PlantGrow>().growAnima;
    }

    private void plantDry()
    {    }

    //iterate through the sprites every sprite time seconds
    public void growSprite()
    {
        Debug.Log(growIndex);
        if(growIndex > (sprites.Count - 1))
        {
            return;
        }
        GetComponent<SpriteRenderer>().sprite = sprites[growIndex];
        growIndex++;
        Invoke("growSprite", growTime);
    }
}
