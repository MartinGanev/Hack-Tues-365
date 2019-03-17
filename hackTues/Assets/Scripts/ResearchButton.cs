using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchButton : MonoBehaviour
{
    public ResearchManager resm;

    public void ClickResearch(Research research)
    {   
        Debug.Log("clicked res: " + research.name);
        resm.unlockResearch(research);
    }
}
