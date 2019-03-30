using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopRes : MonoBehaviour
{
    public Text money;
    public Text res;
    void Start()
    {
    }

    void Update()
    {
        money.text = Resources.Money.ToString();
        res.text = Resources.Research.ToString();
    }
}
