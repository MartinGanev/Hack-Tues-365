using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFlower: MonoBehaviour
{

    public float sun;
    public float sunDec;
    public float sunPerfect;
    public float sunTolerance;

    public float rad;
    public float radTolerance;

    public float water;
    public float waterTolerance;
    public float waterDec;
    public float watering;

    public float soil_req;
    public float growTime;
    public float life;

    public float flowerCost;
    

    public string plantName;

    public bool alive;
    public bool locked;
    public bool Grown;
    public bool nocturnal;
}
