using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class  StaticEvents
{
    public static void MeteorShower(float power)
    {
        Debug.Log("met");
    }
    public static void CosmicRays(float rad)
    {

        Debug.Log("cos");
    }
    public static void SuperNova(float power)
    {

        Debug.Log("sup");
    }
}
