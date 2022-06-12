using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetShift : MonoBehaviour
{
    //Alphabet
    public AlphabetGenerator alphabet;
    //Slider for shifting value
    public Slider slider;
    
    //UI of the shift text
    public TextMeshProUGUI shiftText;

    //Value of the shifting
    private int shiftValue;

    //To add and substract 1 easily
    public void Add(int value)
    {
        shiftValue += value;
        UpdateUI();
    }
    
    //OnChangeValue for the slider => Ajust the shift value
    public void ChangeValue(float value)
    {
        shiftValue = (int) value;
        UpdateUI();
    }
    
    //Update the display 
    private void UpdateUI()
    {
        shiftValue = (shiftValue + 26) % 26;
        shiftText.text = (shiftValue).ToString();
        slider.value = shiftValue;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        shiftValue = alphabet.startIndex;
        UpdateUI();
    }
    
}
