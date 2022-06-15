using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidationReponseScript : MonoBehaviour
{
    public List<ItemSlot> tabItemSlot;
    [SerializeField] private GameObject victoireCanvas;
    [SerializeField] private GameObject defaiteCanvas;

    public void Start()
    {
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
        victoireCanvas.SetActive(true);
    }
    public void DEFAITE()
    {
        defaiteCanvas.SetActive(true);
    }
}
