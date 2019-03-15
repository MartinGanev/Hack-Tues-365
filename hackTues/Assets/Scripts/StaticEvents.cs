using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class  StaticEvents
{
    public static void MeteorShower(float power, FlowerLogic flower)
    {
        
        Debug.Log("met");
    }
    public static void CosmicRays(float rad, FlowerLogic flower)
    {

        Debug.Log("cos");
    }
    public static void SuperNova(float power, FlowerLogic flower)
    {

        Debug.Log("sup");
    }
}
