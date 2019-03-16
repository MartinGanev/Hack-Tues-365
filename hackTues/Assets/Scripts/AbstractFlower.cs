using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFlower: MonoBehaviour
{
    public float water;
    public float sun;
    public float sunDec;
    public float sunPerfect;
    public float SunTolerance;
    public float rad;
    public float waterDec;
    public float waterTolerance;
    public float soil_req;
    public float growTime;
    public float life;
    public float flowerCost;

    protected int growStatus;

    public string plantName;

    public bool alive;
    public bool locked;
    public bool Grown;
    public bool nocturnal;
}
