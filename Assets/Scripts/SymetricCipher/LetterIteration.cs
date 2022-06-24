using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterIteration : MonoBehaviour
{
    //UI Class for one letter => One bar for the cipher text iteration percentage and one bar for the iteration of the letter in french
    public string letter = "A";

    public Bar barForFrench;

    public Bar barForText;
    
    //Distance wanted beatween to letters
    public int spaceBtwLettersIt = 50;

    //Legend
    public TextMeshProUGUI legend;

}
