using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatIsNextButtonScripts : MonoBehaviour
{
    [SerializeField] GameObject canvasWI1;
    [SerializeField] GameObject canvasWI2;
    [SerializeField] GameObject canvasWI3;

    public void SUIVANT1()
    {
        canvasWI2.SetActive(true);
        canvasWI1.SetActive(false);
    }

    public void SUIVANT2()
    {
        canvasWI3.SetActive(true);
        canvasWI2.SetActive(false);
    }

    public void PRECEDENT2()
    {
        canvasWI1.SetActive(true);
        canvasWI2.SetActive(false);
    }

    public void PRECEDENT3()
    {
        canvasWI2.SetActive(true);
        canvasWI3.SetActive(false);
    }
}
