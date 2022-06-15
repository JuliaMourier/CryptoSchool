using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSuivantDH : MonoBehaviour
{
    [SerializeField] GameObject canvasDH;
    [SerializeField] GameObject canvasMainMenu;

    public void SUIVANT()
    {
        canvasDH.SetActive(true);
        canvasMainMenu.SetActive(false);
    }
}
