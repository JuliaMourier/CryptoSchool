using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetGenerator : MonoBehaviour
{
    //Alphabet shifted
    public List<string> alphabet = new List<string>();
    //Index for shift
    public int startIndex = 0;
    //prefab of UI letter
    public Letter letterPrefab;
    //List of letter 
    private List<Letter> letters = new List<Letter>();
    //Color for prefab letters
    public Color letterColor = Color.white;

    //Initialise an alphabet shifted => Associate a number to a letter
    void InitialiseAlphabet()
    {
        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int i = startIndex; i < startIndex + 26; i++)
        {
            alphabet.Add(abc[i % 26].ToString());
        }
    }

    //Display all the letters of the alphabet by instantiating 26 letter prefabs
    void DisplayLetters()
    {
        foreach (string letter in alphabet)
        {
            Letter gb = Instantiate(letterPrefab, transform);
            //Set the text to have the right letter
            gb.GetComponentInChildren<TextMeshProUGUI>().text = letter;
            //Set the color 
            gb.GetComponentInChildren<Image>().color = letterColor;
            //Add it to the list
            letters.Add(gb);
        }   
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        InitialiseAlphabet();
        DisplayLetters();
    }

    //Allow the alphabet to be shifted 
    public void Shift(float shift)
    {
        int shifti = (int) shift;
        for (int i = startIndex; i < startIndex + 26; i++)
        {
            letters[i % 26].GetComponentInChildren<TextMeshProUGUI>().text = alphabet[(i + shifti ) % 26];
        }
    }

    //Static function allowing to get an alphabet
    public static List<string> GetAnAlphabet()
    {
        List<string> alph = new List<string>();
        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int i = 0; i < 26; i++)
        {
            alph.Add(abc[i].ToString());
        }

        return alph;
    }
}
