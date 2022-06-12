using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlphabetGenerator : MonoBehaviour
{
    public List<string> alphabet = new List<string>();
    public int startIndex = 0;
    public Letter letterPrefab;
    private List<Letter> letters = new List<Letter>();
    void InitialiseAlphabet()
    {
        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int i = startIndex; i < startIndex + 26; i++)
        {
            alphabet.Add(abc[i % 26].ToString());
        }
    }

    void DisplayLetters()
    {
        foreach (string letter in alphabet)
        {
            Letter gb = Instantiate(letterPrefab, transform);
            gb.GetComponentInChildren<TextMeshProUGUI>().text = letter;
            letters.Add(gb);
        }   
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("oizfh");
        InitialiseAlphabet();
        DisplayLetters();
    }

    public void Shift(float shift)
    {
        int shifti = (int) shift;
        for (int i = startIndex; i < startIndex + 26; i++)
        {
            letters[i % 26].GetComponentInChildren<TextMeshProUGUI>().text = alphabet[(i + shifti ) % 26];
        }
    }
}
