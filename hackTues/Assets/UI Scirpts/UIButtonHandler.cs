using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHandler : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject store;
    public GameObject researchScreen;
    public GameObject pauseMenu;
    public GameObject contractMenu;

    void Start()
    {
        gameUI.SetActive(true);
        store.SetActive(false);
        researchScreen.SetActive(false);
        pauseMenu.SetActive(false);
        contractMenu.SetActive(false);
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
