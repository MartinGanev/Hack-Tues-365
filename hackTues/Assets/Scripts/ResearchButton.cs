using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchButton : MonoBehaviour
{
    public ResearchManager resm;

    public void ClickResearch(Research research)
    {
        Debug.Log("clicked res: " + research.name);
        resm.unlockResearch(research);
    }
}
