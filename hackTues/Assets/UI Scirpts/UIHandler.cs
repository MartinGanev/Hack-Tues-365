using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject pauseMenu;
    public GameObject researchScreen;

    public GameObject store;
    public GameObject storePrefab;
    public GameObject storeContent;

    public GameObject contractMenu;
    public GameObject contractPrefab;
    public GameObject contractContent;

    void Start()
    {
        gameUI.SetActive(true);
        store.SetActive(false);
        researchScreen.SetActive(false);
        pauseMenu.SetActive(false);
        contractMenu.SetActive(false);
    }

    void AddStoreItem(string name, int cost, string description)
    {
        GameObject newStoreItem = Object.Instantiate(contractPrefab, new Vector3(), Quaternion.identity, storeContent.transform);

        foreach (Text text in newStoreItem.GetComponentsInChildren<Text>())
        {
            if (text.name == "Name")
            {
                text.text = name;
            }
            else if (text.name == "Cost")
            {
                text.text = cost.ToString();
            }
            else if (text.name == "Description")
            {
                text.text = description;
            }
        }
    }

    void AddContract(string name, int money, int research, string description)
    {
        GameObject newContract = Object.Instantiate(contractPrefab,new Vector3(),Quaternion.identity,contractContent.transform); 

        foreach(Text text in newContract.GetComponentsInChildren<Text>())
        {
            if(text.name == "Name")
            {
                text.text = name;
            }
            else if (text.name == "Money")
            {
                text.text = money.ToString();
            }
            else if (text.name == "Research")
            {
                text.text = research.ToString(); 
            }
            else if (text.name == "Description")
            {
                text.text = description ;
            }
        }
    }

    public void OpenStore()
    {
        store.SetActive(true);
    }
    public void CloseStore()
    {
        store.SetActive(false);
    }
    public void OpenResearch()
    {
        researchScreen.SetActive(true);
    }
    public void CloseResearch()
    {
        researchScreen.SetActive(false);
    }
    public void OpenContract()
    {
        contractMenu.SetActive(true);
    }
    public void CloseContract()
    {
        contractMenu.SetActive(false);
    }
}
