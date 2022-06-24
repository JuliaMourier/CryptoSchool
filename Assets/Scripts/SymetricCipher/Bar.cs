using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{

    //Percentage of the element
    public float percentage = 0.0f;
    //Max size for the heigth of the bar
    public static int MAX_SIZE = 200;
    //boolean if the language used is french
    public bool isFrench = true;


    //Calculate the height in function of the value of the percentage
    public float CalculateHeightForPercentage()
    {
        return percentage/100*5 * MAX_SIZE;
    }
    
    
    //Set the correspondin height
    public void SetHeight()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2 ( 24, CalculateHeightForPercentage());
    }
}
