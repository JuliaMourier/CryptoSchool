using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidationReponseScript : MonoBehaviour
{
    public List<ItemSlot> tabItemSlot;
    [SerializeField] private GameObject victoireCanvas;
    [SerializeField] private GameObject defaiteCanvas;
    private GameManager levelManager;
    public void Start()
    {
        levelManager = FindObjectOfType<GameManager>();
    }
    public void ValidationButton()
    {
        bool res = true;

        foreach(ItemSlot item in tabItemSlot)
        {
            res = item.ValidationReponseItem();
            if (!res)
                break;
        }

        if (res)
            VICTOIRE();
        else
            DEFAITE();

    }

    public void VICTOIRE()
    {
        //victoireCanvas.SetActive(true);
        levelManager.hasWinLevel = true;

    }
    public void DEFAITE()
    {
        defaiteCanvas.SetActive(true);
    }
}
