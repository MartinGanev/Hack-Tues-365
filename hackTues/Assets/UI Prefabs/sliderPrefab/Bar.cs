using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Bar : MonoBehaviour
{
    public int p = 100;


    public void SetBarPercent(float percent)
    {
        if(percent > 100)
        {
            percent = 100;
        }
        else if(percent < 0)
        {
            percent = 0;
        }
        Transform b = transform.Find("BarSetup").transform;
        b.localScale = new Vector3(percent / 100, b.localScale.y, b.localScale.z);
    }
}
