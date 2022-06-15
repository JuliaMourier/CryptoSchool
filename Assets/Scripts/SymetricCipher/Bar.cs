using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{

    public float percentage = 0.0f;
    
    public static int MAX_SIZE = 200;

    public bool isFrench = true;


    public float CalculateHeightForPercentage()
    {
        return percentage/100*5 * MAX_SIZE;
    }

    public void SetHeight()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2 ( 24, CalculateHeightForPercentage());
    }
}
