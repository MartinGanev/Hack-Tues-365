using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyHandler : MonoBehaviour
{
    public FlowerLogic flower;
    public GameManager gm;
    public void press()
    {
        gm.buyFlower(flower);
    }
}
