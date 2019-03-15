using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager: MonoBehaviour
{
    public int resAmount;
    private string[] names = { "Cactus", "Tulip", "Sunflower", "Weed"};
    private int[] level = { 1, 2, 2, 3};

    public static Research[] resUnlock;
    public static Research[] resLock;

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
        Research.
    }
}
