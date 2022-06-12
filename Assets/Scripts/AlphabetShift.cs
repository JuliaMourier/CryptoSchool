using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetShift : MonoBehaviour
{
    public AlphabetGenerator alphabet;

    public Slider slider;

    public TextMeshProUGUI shiftText;

    private int shiftValue;

    public void Add(int value)
    {
        shiftValue += value;
        UpdateUI();
    }
    
    public void ChangeValue(float value)
    {
        shiftValue = (int) value;
        UpdateUI();
    }
    private void UpdateUI()
    {
        shiftValue = (shiftValue + 26) % 26;
        shiftText.text = (shiftValue).ToString();
        Debug.Log(shiftValue);
        slider.value = shiftValue;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        shiftValue = alphabet.startIndex;
        UpdateUI();
    }

}
