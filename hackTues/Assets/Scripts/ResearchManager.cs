using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager: MonoBehaviour
{
    private string[] names = { "Cactus", "Tulip", "Sunflower", "Weed"};
    private int[] level = { 1, 2, 2, 3};

    public List<Research> resUnlock;
    public List<Research> resLock;

    private void Start()
    {
        /*for (int i = 0; i < resAmount; i++)
        {
            resLock[i] = new Research();
            resLock[i].name = names[i];
        }*/

    }

    public void unlockResearch(Research res)
    {
        if (Resources.Research >= res.Cost) {
            Resources.Research -= res.Cost;
            res.Locked = false;

            resLock.Remove(res);
            resUnlock.Add(res);
            Debug.Log("Researched: " + res.name);
        }
    }
}
