using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Soil {good,bad,black,average};

public class Planet : MonoBehaviour
{
    public string name;
    public Sprite Image;

    public float gravity = 9.81f;
    public float Humidity
    {
        get
        {
            return Humidity;
        }
        set
        {
            if(value < 0)
            {
                Humidity = 0;
            }
            else if(value > 100)
            {
                Humidity = 100;
            }
        }
    }
    public float O2
    {
        get
        {
            return O2;
        }
        set
        {
            if (value < 0)
            {
                O2 = 0;
            }
            if (value > 100)
            {
                O2 = 100;
            }
            if(value + C02 > 100)
            {
                O2 = 100 - C02;
            }
        }
    }
    public float C02
    {
        get
        {
            return C02;
        }
        set
        {
            if (value < 0)
            {
                C02 = 0;
            }
            if (value > 100)
            {
                C02 = 100;
            }
            if(value + O2 > 100)
            {
                C02 = 100 - O2;
            }
        }
    }
    public float Radiation
    {
        get
        {
            return Radiation;
        }
        set
        {
            if (value < 0)
            {
                Radiation = 0;
            }
            else if (value > 100)
            {
                Radiation = 100;
            }
        }
    }
    public float day;
    public float night;
    public float DayNightCycle
    {
        get
        {
            return day + night;
        }
    }
    public float temperature;
    public Soil soil;
    
}
