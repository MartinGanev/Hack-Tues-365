using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResearchManager: MonoBehaviour
{
    private int levelResearch = 1;
    //private string[] names = { "Cactus", "Tulip", "Sunflower", "Weed"};
    //private int[] level = { 1, 2, 2, 3};

    public int levelNum = 3;
    public List<Research> resUnlock;
    public List<Research> resLock;

    private List<int> checkLevelHelp = new List<int>();

    private void Start()
    {
        for (int i = 0; i < levelNum; i++)
        {
            checkLevelHelp.Add(0);
        }
        foreach (Research res in resLock)
        {
            checkLevelHelp[res.level - 1]++; 
        }

        /*for (int i = 0; i < resAmount; i++)
        {
            resLock[i] = new Research();
            resLock[i].name = names[i];
        }*/

    }

    public void unlockResearch(Research res)
    {
        if (Resources.Research >= res.Cost && !res.Own && res.level <= levelResearch) {
            Resources.Research -= res.Cost;
            res.Locked = false;

            resLock.Remove(res);
            res.Own = true;
            resUnlock.Add(res);
            checkLevelHelp[res.level-1]--;
            if (checkLevelHelp[res.level-1] <= 0)
            {
                levelResearch++;
            }
            Debug.Log("Researched: " + res.name + "at: " + levelResearch);
        }
    }
}
